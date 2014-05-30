using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using CSharpProsjekt.SpillKlasser;
using CSharpProsjekt.LoginKlasser;
using System.Drawing.Drawing2D;
using System.Media;

namespace CSharpProsjekt
{
    /// <summary>
    /// MyPanel.cs av Tommy Langhelle & Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Her blir alt tegnet fra. Alle funksjonene med spillet begynner her i fra.
    /// </summary>
    
    //Oppretter delegatene vi har
    public delegate void TimeEndringEvent(Object sender, TimeEventArgs e);
    public delegate void PointEndringEvent(Object sender, PointEventArgs e);
    public delegate void FPSEndringsEvent(Object sender, FPSEventArgs e);

    public partial class MyPanel : Panel
    {
        //Events av alle delegater
        public event TimeEndringEvent TimeEndret;
        public event PointEndringEvent PointsEndret;
        public event FPSEndringsEvent FPSEndret;

#region Variabler
        private Object mySync = new Object();
        private Level loadLevel;
        private Player player;

        //Listene som blir tegnet
        private List<Obstacle> listOfObstacles = new List<Obstacle>();
        private List<Smiley> listOfSmileys = new List<Smiley>();
        private List<Canon> listOfCanons = new List<Canon>();
        private List<Bullet> listOfBullets = new List<Bullet>();

        //Alle graphicspather
        static GraphicsPath startPlatformPath = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath canonPath = new GraphicsPath();

        //Alle region som vi har
        static Region platformRegion;
        static Region obstacleRegion;
        static Region canonRegion;

        //Diverse farge egenskaper
        private Pen colorPen = new Pen(Color.WhiteSmoke, 1);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush bulletBrush = new SolidBrush(Color.Black);

        //Diverse lydeffekter
        private SoundPlayer gunFireSound = new SoundPlayer(Resource.GunFire);
        private SoundPlayer introSound = new SoundPlayer(Resource.IntroMusic);
        private SoundPlayer gameOverSound = new SoundPlayer(Resource.GameOver);
        private SoundPlayer gameWonSound = new SoundPlayer(Resource.GameWon);

        private DbConnect db = new DbConnect();
        private Random rnd = new Random();
        private Boolean gameFinished = false; //Om alle baner er spilt igjennom
        private Boolean runnedOnce = false; //For å hindre at region blir satt ved hver onpaint
        private Boolean firstAttempt = true; //Så timerene ikke blir satt ved hver level
        private Boolean levelFinished = false; 
        private Boolean gameOver = false;
        private int smileysRemaining;
        public int timeLeft; //Stoppeklokke, hvor lang tid man har igjen på banen
        private int level = 1;
        private int points;

        //Thread / Timer
        private ThreadStart ts;
        private Thread thread;
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();
        
        //FPS:
        private int frameCount = 0;
        private double timeSinceLastUpdate = 0;
        private double fps = 0;
        private DateTime lastTime = DateTime.Now;
#endregion

        public MyPanel()
        {
            introSound.Play();
            
            
            //Må sittes her for at .heigth og .width skal returnere riktig verdi.
            this.Size = new System.Drawing.Size(728, 404);

            //sørger for at grafikken går smooth
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();
        }

#region Timer & Thread metoder
        /// <summary>
        /// Metoden blir trigret hvert 15ms av en thred og sjekker om pil opp, ned, venstre eller høyre er trykt. 
        /// Klassen KeyboardInfo blir brukt, dette er en ferdig klasse funnet på nettet som tillater oss å trykke flere taster ned samtidig. 
        /// </summary>
        public void Run()
        {
            while (thread.IsAlive)
            {
                Movement();
                Thread.Sleep(15);
            }
        }

        public void Movement()
        {
            lock (mySync)
            {
                var left = KeyboardInfo.GetKeyState(Keys.Left);
                var right = KeyboardInfo.GetKeyState(Keys.Right);
                var up = KeyboardInfo.GetKeyState(Keys.Up);
                var down = KeyboardInfo.GetKeyState(Keys.Down);

                if (left.IsPressed)
                {
                    player.MoveLeft();
                }

                if (right.IsPressed)
                {
                    player.MoveRight();
                }

                if (up.IsPressed)
                {
                    player.MoveUp();
                }

                if (down.IsPressed)
                {
                    player.MoveDown();
                }
            }
        }

        /// <summary>
        /// Timeren countdownTimer trigrer denne metoden hvert sekund. 
        /// Metoden oppretter så instans av custom EventArgs TimeEventArgs og 
        /// sender med int verdien timeLeft(som er resterende sekunder) i delegaten TimeEndret.
        /// BallSpill.cs abonnerer på delegaten
        /// </summary>
        void Countdown_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                try
                {
                    TimeEventArgs te = new TimeEventArgs(timeLeft);
                    TimeEndret(this, te);
                }
                catch (System.NullReferenceException exp)
                {
                    MessageBox.Show(string.Format("error: {0}", exp.ToString()));
                }
            }
            else
            {
                gameOver = true;
                StopGame();
            }
        }

        /// <summary>
        /// Timeren bulletTimer trigrer denne metoden med en random verdi mellom 0.5 - 1 sekund
        /// Medoden lager så en random verdi fra 0 - 3 som han sender inn til Level klassen
        /// for så å lage en ny kule. Random verdien er til for lage en kule fra en kanon
        /// om gangen, slik at kulene ikke blir så synkrone fra skyterene.
        /// </summary>
        void Interval_Tick(object sender, EventArgs e)
        {
            int i = rnd.Next(0, 4);

            listOfBullets = loadLevel.GetBullets(i);
        }
#endregion

#region Ny/Start/Pause/Stop metoder for gamet
        /// <summary>
        /// Viss man lager et nytt spill, så legge til event på hver timer og setter intervallet de
        /// skal gå i.
        /// Ellers vil den starte gamet med å starte/enable alle timerene, resette poengene og opprette
        /// ett nytt spill objekt
        /// </summary>
        public void StartGame()
        {
            if (firstAttempt)
            {
                countdownTimer.Interval = 1000;
                countdownTimer.Tick += new EventHandler(Countdown_Tick);
                
                bulletTimer.Interval = rnd.Next(500, 1000);
                bulletTimer.Tick += new EventHandler(Interval_Tick);
                
                firstAttempt = false;
            }

            StartTimers();
            StartMovementThread();
            points = 0;
            UpdatePoints();
            player = new Player(this);
        }

        /// <summary>
        /// stopper/starter timere og gamet ved å trykke på pause/fortsette knappen
        /// </summary>
        public Boolean PauseGame()
        {
            if (thread.IsAlive)
            {
                player.ThreadStop();
                StopTimers();
                StopMovementThread();
                return false;
            }
            else
            {
                StartTimers();
                player.ThreadStart();
                StartMovementThread();
                return true;
            }
        }

        /// <summary>
        /// Stopper gamet/timerene, rydder hele panelet for objekter slik at man bare ser bakgrunnsbilde.
        /// Oppdatere databasen og resetter poengsummen
        /// </summary>
        public void StopGame()
        {
            StopTimers();
            StopMovementThread();
            ClearPanel();
            player = null;
            UpdatePoints();

            if (points > User.TopScore)
                this.UpdateDatabase();
        }

        /// <summary>
        /// Starter et nytt game ved å resette spilleren sin posisjon tilbake til start
        /// setter gameOver til false, resette level verdien og tegner opp levelet igjen
        /// </summary>
        public void NewGame()
        {
            if(player != null)
                player.ResetPosition();

            gameOver = false;
            level = 1;
            LoadLevel();
        }
#endregion

#region Start/stop metoder for timers
        /// <summary>
        /// Starter alle timere
        /// </summary>
        public void StartTimers()
        {
            bulletTimer.Start();
            countdownTimer.Start();
        }

        /// <summary>
        /// Stopper alle timerene som vi bruker
        /// </summary>
        /// <param name="verdi"></param>
        public void StopTimers()
        {
            bulletTimer.Stop();
            countdownTimer.Stop();
        }
#endregion

#region Movement thread
        /// <summary>
        /// Start stop metoder for bevegelsestråden for spilleren(keyinput)
        /// </summary>
        private void StopMovementThread()
        {
            thread.Abort();
        }

        public void StartMovementThread()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }
#endregion
        
        /// <summary>
        /// Sjekker om region1 og region2 kolliderer. 
        /// Om region1 ikke er tom etter .Intersect har det vert en kollisjon
        /// </summary>
        private Boolean CheckCollision(GraphicsPath path1, GraphicsPath path2, PaintEventArgs e)
        {
            Region region1 = new Region(path1);
            Region region2 = new Region(path2);

            region1.Intersect(region2);

            if (!region1.IsEmpty(e.Graphics))
            {
                return true;
            }
            else
            {
                return false;
            }          
        }
        
        /// <summary>
        /// fyller opp loadLevel objektet Level med int level som parameter. 
        /// En Switch case i Level klassen fyller tabeller med riktig info som blir tilgjengelig 
        /// via get metoder. Tiden blir startet og levelFinished blir satt til false, 
        /// slik at diverse if setninger i onPaint blir true.
        /// </summary>
        public void LoadLevel()
        {
            //Hvis gravitasjonen er reversert fra utgangspunkt, vil den bli snudd til normal gravitasjon
            if (player != null && player.GravityReversed)
                player.ReverseGravity();
            
            UpdatePoints();

            StartPlatform();
            loadLevel = new Level(level);

            //Oppdatere de forskjellige listene og time left med riktig verdier for level
            timeLeft = loadLevel.GetTimeLeft();
            listOfObstacles = loadLevel.GetObstacles();
            listOfCanons = loadLevel.GetCanons();
            listOfSmileys = loadLevel.GetSmileys();

            //Teller antall gule smileyer i listOfSmileys, ettersom alle andre smileyer er valgfrie. 
            //SmileysRemaining brukes senere for å sjekke om alle gule smileyer er tatt.
            smileysRemaining = 0;
            foreach (Smiley s in listOfSmileys)
                if (s.Value == 100)
                    smileysRemaining++;

            runnedOnce = false;
            levelFinished = false;
            gameOver = false;
            gameFinished = false;
        }

        /// <summary>
        /// Alle lister med objekter blir tømt, samt graphicsPath og regions. 
        /// Timer/Thread for keyboardinput og countdown og kulene stoppes.
        /// </summary>
        public void ClearPanel()
        {
            listOfObstacles.Clear();
            listOfCanons.Clear();
            listOfSmileys.Clear();
            listOfBullets.Clear();

            obstaclePath.Reset();
            startPlatformPath.Reset();
            canonPath.Reset();

            obstacleRegion.MakeEmpty();
            platformRegion.MakeEmpty();
            canonRegion.MakeEmpty();

            StopTimers();
            StopMovementThread();
        }

        /// <summary>
        /// Egendefinert EventArgs PointEventArgs blir tildelt parametere, og sendt inn i 
        /// delegatet PointsEndret. Dette blir abonnert på i BallSpill.cs for å oppdatere panelet i bunn.
        /// </summary>
        private void UpdatePoints()
        {
            try
            {
                PointEventArgs te = new PointEventArgs(points, level, levelFinished, gameFinished, gameOver);
                PointsEndret(this, te);
            }
            catch (System.NullReferenceException exp)
            {
                MessageBox.Show(string.Format("error: {0}", exp.ToString()));
            }
        }

        /// <summary>
        /// Opdatere databasen og bruker objekt klassen med brukerens største topscore.
        /// Level vil også bli oppdatert da.
        /// </summary>
        private void UpdateDatabase()
        {
            if (level == 6)
                level = 5;

            string query = String.Format("UPDATE Konto SET TopScore = '{0}', Level = '{1}' WHERE Navn = '{2}'", points, level, User.Name);
            db.InsertAll(query);
            User.AddTopScoreLevelToUser(points, level);
        }

        /// <summary>
        /// Hentet fra dokument i mappen "uke 15" under programmering 3 på itslearning.
        /// Teller antall kall på onPaint i sekundet og sender dette til PlayBall.cs panelet via delegat
        /// </summary>
        /// <param name="elapsed"></param>
        private void CalculateFPS(double elapsed)
        {
            //Teller antall frames:
            frameCount++;
            //Inkrementerer timeSinceLastUpdate med forløpt tid:
            timeSinceLastUpdate += elapsed;
            //Når det er gått mer enn 1 sekund (timeSinceLastUpdate > 1) beregnes fps:
            if (timeSinceLastUpdate > 1.0)
            {
                fps = frameCount / timeSinceLastUpdate;
                
                try
                {
                    FPSEventArgs ea = new FPSEventArgs(fps);
                    FPSEndret(this, ea);

                }
                catch (System.NullReferenceException exp)
                {
                    MessageBox.Show(string.Format("error: {0}", exp.ToString()));
                }

                frameCount = 0;
                timeSinceLastUpdate -= 1.0; //Reduserer med 1 sekund, timeSinceLastUpdate blir (ca.) 0.
            }
        }

        /// <summary>
        /// Oppretter Obstacle i venstre hjørne hvor spilleren begynner oppå.
        /// </summary>
        private void StartPlatform()
        {
            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatformPath.AddRectangle(start);
            startPlatformPath.CloseFigure();
        }

        /// <summary>
        /// Produsert av Tommy & Frederik
        /// 
        /// Her skjer alt av tegning til panelet. Bestemmer også om det skal være gameover.
        /// Bestemmer også hva som skal skje om kollisjon på brettet skjer
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Finner antall ticks siden sist (10000 ticks per millisekund):
            long elapsedTicks = DateTime.Now.Ticks - lastTime.Ticks;        //lastTime sette nederst i calculateFPS metoden.
            //Finner differansen som et timespan-objekt:
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            //Finner forløpt tid siden siste kall på OnPaint- i antall sekunder:
            double elapsed = (elapsedSpan.Milliseconds) / 1000.0; //NB! .0
            //Beregner og trigrer delegat:
            CalculateFPS(elapsed);
            //Setter lastTime:
            lastTime = DateTime.Now;

            Graphics g = e.Graphics;

            //Om det er game over, så skal man stoppe gamet, også tegne en ny tegning hvor det står 
            // game over med store bokstaver. Denne skjøres også bare en gang
            if (gameOver && runnedOnce)
            {
                gameOverSound.Play();
                StopGame();
                obstaclePath.AddString("Game Over", new FontFamily("Showcard Gothic"), (int)(FontStyle.Bold | FontStyle.Italic), 120, new Point(5, 100), StringFormat.GenericTypographic);
                obstacleRegion = new Region(obstaclePath);
                runnedOnce = false;
            }
            //Om siste bane er fullført blir dette if setningen kjørt
            if (gameFinished)
            {
                StopGame();
                gameWonSound.Play();
                obstaclePath.AddString("Game Finished \nCongratz!", new FontFamily("Showcard Gothic"), (int)(FontStyle.Bold | FontStyle.Italic), 90, new Point(5, 100), StringFormat.GenericTypographic);
                obstacleRegion = new Region(obstaclePath);
            }

            //Denne kodesnutten blir bare kjørt en gang for hver level. 
            //Obstacles og canons har ingen behov for å bli lagt til graphicsPath i hver onpaint ettersom de er statisk.
            if (runnedOnce == false && gameOver == false)
            {
                for (int i = 0; i < listOfObstacles.Count; i++)
                {
                    obstaclePath.AddPath(listOfObstacles[i].obstacle, true);
                }

                for (int i = 0; i < listOfCanons.Count; i++)
                {
                    canonPath.AddPath(listOfCanons[i].canonPath, true);
                }

                platformRegion = new Region(startPlatformPath);
                obstacleRegion = new Region(obstaclePath);
                canonRegion = new Region(canonPath);

                runnedOnce = true;
            }

            //Fyller regions med farge, og tegner omriss. SmoothingMode sørger for et 
            //finere og glattere utseende på tegninger
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //For hindrene
            g.FillRegion(purpleBrush, obstacleRegion);
            g.DrawPath(colorPen, obstaclePath);

            //For start platformen
            g.FillRegion(purpleBrush, platformRegion);
            g.DrawPath(colorPen, startPlatformPath);

            //For kanonene
            g.FillRegion(Canon.GetColor(), canonRegion);
            g.DrawPath(colorPen, canonPath);

#region Spillet er startet
            //Hvis spillet er i gang, skjer dette
            if (this.player != null)
            {
                player.Draw(g);

                //Sjekker om spilleren kommer ned på bunnen, viss det skjer er det game over
                if (player.Y + player.Diameter >= this.Height)
                    gameOver = true;

                //Sjekker om det er flere gule smileyer igjen og at tiden ikke har gått ut. 
                //levelFinished sørger for at diverse if setninger bare kjører en gang, samt 
                //verdien blir sendt videre via en delegat til BallSpill.cs
                if (smileysRemaining == 0 && levelFinished == false)
                {
                    gameWonSound.Play();
                    player.ResetPosition();
                    StopTimers();
                    StopMovementThread();
                    levelFinished = true;

                    //Gir 2 poeng for hvert sekund som er igjen, liten bonus
                    points += timeLeft * 2;

                    level++;
                    if (level > 5)
                        gameFinished = true;

                    UpdatePoints();
                    //Rydder brettet slik at neste brett og forrige brett ikke blir tegnet oppå hverandre
                    ClearPanel();
                }

                //Sjekker at spillet fortsatt går
                if (levelFinished == false)
                {
                    //kjører igjennom hvert objekt i listOfBullets og printer disse til skjermen. 
                    //Sjekker også collision mot obstacles og spiller
                    //Måtte tegne ballene her i graphicspath fordi at viss man gjorde dette i 
                    //objekt klassen, så ville x og y verdien være konstante og kollisjon med noen ting
                    //ville aldri har skjedd siden x og y verdien forsatt være på start punktet til ballen.
                    //Med å tegne graphicspathen her vil x og y verdien hele tiden følge ballen og 
                    //kollisjon vil oppstå om det skjer
                    for (int i = 0; i < listOfBullets.Count; i++)
                    {
                        Bullet bullet = listOfBullets[i];

                        GraphicsPath bulletPath = new GraphicsPath();
                        bulletPath.StartFigure();
                        bulletPath.AddEllipse(bullet.X, bullet.Y, bullet.Diameter, bullet.Diameter);
                        bulletPath.CloseFigure();

                        bullet.Draw(g);

                        //Sjekker kollisjon opp i mot spilleren
                        if (CheckCollision(bulletPath, player.GetPath(), e))
                        {
                            gameOver = true;
                        }
                        //Sjekker kollisjon opp i mot hindrene og brett kanten og fjerner den fra listen
                        if (CheckCollision(bulletPath, obstaclePath, e) || bullet.X > this.Width || bullet.Y > this.Height || bullet.X < 0 || bullet.Y < 0)
                        {
                            listOfBullets.RemoveAt(i);
                        }
                    }

                    //Kjører igjennom hvert objekt i listOfSmileys og printer disse til skjermen. 
                    //Sjekker også collision mot spiller.
                    for (int i = 0; i < listOfSmileys.Count; i++)
                    {
                        Smiley smiley = listOfSmileys[i];

                        smiley.Draw(g);

                        //Sjekker kollisjon mot spilleren, skjer det så oppdatere den smileyremaining
                        //verdien for smiley som må tas(om smileyen er gule). 
                        //er smileyen rød, vil man bytte gravitasjonen
                        //også fjerne smileyen fra listen så den ikke blir tegnet igjen
                        if (CheckCollision(smiley.GetPath(), player.GetPath(), e))
                        {
                            gunFireSound.Play();
                            listOfSmileys.RemoveAt(i);
                            points += smiley.Value;

                            //Sjekker om smileyen er gul, for så å fjerne en count fra int variabelen smileysRemaining.
                            if (smiley.Value == 100)
                                smileysRemaining--;

                            //Om smileyen er rød kjøres reverse gravity på spilleren.
                            if (smiley.Value == 150)
                                player.ReverseGravity();

                            UpdatePoints();
                        }
                    }

                    //Sender spiller tilbake til start om det blir detected collision mot obstacle eller canon.
                    //Viss det skjer en kollisjon vil poengene trekkes med 75
                    if (CheckCollision(obstaclePath, player.GetPath(), e) || CheckCollision(canonPath, player.GetPath(), e))
                    {
                        player.ResetPosition();
                        points -= 75;

                        UpdatePoints();
                    }
                }
            }
#endregion
        }
    } 
}
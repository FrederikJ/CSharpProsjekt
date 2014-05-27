using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{

    class Level
    {
        private List<Obstacle> listOfObstacles = new List<Obstacle>();
        private List<Smiley> listOfSmileys = new List<Smiley>();
        private List<Canon> listOfCanons = new List<Canon>();
        private List<Bullet> listOfBullets = new List<Bullet>();

        private int level;
        //private MyPanel parentPanel = new MyPanel();

        public Level(int _level)
        {
            level = _level;

            switch (_level)
            {
                case 1:
                    LevelOne();
                    break;

                case 2:
                    LevelTwo();
                    break;

                case 3:
                    LevelThree();
                    break;
                case 4:
                    LevelFour();
                    break;
            }
        }

        public List<Obstacle> GetObstacles()
        {
            return listOfObstacles;
        }

        public List<Smiley> GetSmileys()
        {
            return listOfSmileys;
        }

        public List<Canon> GetCanons()
        {
            return listOfCanons;
        }

        public List<Bullet> GetBullets()
        {
            return listOfBullets;
        }

        private void LevelOne()
        {
            listOfObstacles.Add(new Obstacle(500, 180, 200, 70, 50, 180));
            listOfObstacles.Add(new Obstacle(70, 180, 150, 100, 300, -180));
            listOfObstacles.Add(new Obstacle(400, 70));
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
            listOfObstacles.Add(new Obstacle(220, 200, 200, 70, 50, -150));
            listOfObstacles.Add(new Obstacle(400, 310, 100, 30));
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 150));
            listOfObstacles.Add(new Obstacle(5, 110, 220, 20));

            listOfSmileys.Add(new Smiley(110, 80, 1));
           /* listOfSmileys.Add(new Smiley(450, 250, 1));
            listOfSmileys.Add(new Smiley(560, 213, 2));
            listOfSmileys.Add(new Smiley(510, 65, 1));
            listOfSmileys.Add(new Smiley(660, 75, 1));
            listOfSmileys.Add(new Smiley(660, 145, 2));
            listOfSmileys.Add(new Smiley(360, 65, 2));
            listOfSmileys.Add(new Smiley(130, 140, 1));
            listOfSmileys.Add(new Smiley(5, 40, 2));*/

            listOfCanons.Add(new Canon(190, 404, "up"));
            listOfCanons.Add(new Canon(440, 0, "down"));
            listOfCanons.Add(new Canon(530, 404, "up"));
            listOfCanons.Add(new Canon(620, 110, "left"));
        }
        private void LevelTwo()
        {
            listOfObstacles.Add(new Obstacle(400, 180, 200, 70, 50, 180));
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));

            listOfSmileys.Add(new Smiley(150, 280, 1));
            listOfSmileys.Add(new Smiley(660, 75, 1));

            listOfCanons.Add(new Canon(440, 0, "down"));
            listOfCanons.Add(new Canon(220, 404, "up"));
        }

        private void LevelThree()
        {
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 150));

            listOfSmileys.Add(new Smiley(510, 65, 1));
            listOfSmileys.Add(new Smiley(130, 140, 1));

            listOfCanons.Add(new Canon(530, 404, "up"));
            listOfCanons.Add(new Canon(620, 110, "left"));
        }
        private void LevelFour()
        {
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
            listOfObstacles.Add(new Obstacle(220, 200, 200, 70, 50, -150));

            listOfSmileys.Add(new Smiley(560, 213, 2));
            listOfSmileys.Add(new Smiley(510, 65, 1));

            listOfCanons.Add(new Canon(530, 404, "up"));
            listOfCanons.Add(new Canon(620, 110, "left"));
        }
    }
}

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

        private int canonUpX;
        private int canonUpY;

        private int canonDownX;
        private int canonDownY;

        private int canonLeftX;
        private int canonLeftY;

        private int canonRightX;
        private int canonRightY;

        private int level;
        private int timeLeft;

        public Level(int _level)
        {
            level = _level;

            switch (_level)
            {
                case 1:
                    timeLeft = 30;
                    LevelOne();
                    break;

                case 2:
                    timeLeft = 40;
                    LevelTwo();
                    break;

                case 3:
                    timeLeft = 70;
                    LevelThree();
                    break;
                case 4:
                    timeLeft = 120;
                    LevelFour();
                    break;
                case 5:
                    timeLeft = 120;
                    LevelFive();
                    break;
            }
        }

        public int GetTimeLeft()
        {
            return timeLeft;
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

        public List<Bullet> GetBullets(int i)
        {
            switch (i)
            {
                case 0:
                    listOfBullets.Add(new Bullet(canonRightX + 30, canonRightY + 10, "right"));
                    break;
                case 1:
                    listOfBullets.Add(new Bullet(canonDownX + 10, canonDownY + 30, "down"));
                    break;
                case 2:
                    listOfBullets.Add(new Bullet(canonUpX + 10, canonUpY - 30, "up"));
                    break;
                case 3:
                    listOfBullets.Add(new Bullet(canonLeftX - 30, canonLeftY + 10, "left"));
                    break;
                default:
                    break;
            }
            return listOfBullets;
        }

        private void LevelOne()
        {
            canonDownX = 565;
            canonDownY = 95;

            canonUpX = 150;
            canonUpY = 305;

            canonLeftX = 728;
            canonLeftY = 200;

            canonRightX = 0;
            canonRightY = 200;

            listOfObstacles.Add(new Obstacle(350, 100, 30, 200));
            listOfObstacles.Add(new Obstacle(100, 65, 500, 30));
            listOfObstacles.Add(new Obstacle(100, 305, 500, 30));
            listOfObstacles.Add(new Obstacle(200, 135, 30, 125));
            listOfObstacles.Add(new Obstacle(500, 135, 30, 125));
            listOfObstacles.Add(new Obstacle(350, 5, 30, 50));

            listOfSmileys.Add(new Smiley(275, 160, 2));
            listOfSmileys.Add(new Smiley(275, 200, 3));
            listOfSmileys.Add(new Smiley(425, 160, 3));
            listOfSmileys.Add(new Smiley(425, 200, 2));
            listOfSmileys.Add(new Smiley(350, 350, 1));
            listOfSmileys.Add(new Smiley(300, 20, 1));
            listOfSmileys.Add(new Smiley(400, 20, 2));

            listOfCanons.Add(new Canon(canonRightX, canonRightY, "right"));
            listOfCanons.Add(new Canon(canonDownX, canonDownY, "down"));
            listOfCanons.Add(new Canon(canonUpX, canonUpY, "up"));
            listOfCanons.Add(new Canon(canonLeftX, canonLeftY, "left"));
        }

        private void LevelTwo()
        {
            canonDownX = 345;
            canonDownY = 0;

            canonUpX = 355;
            canonUpY = 404;

            canonLeftX = 728;
            canonLeftY = 210;

            canonRightX = 0;
            canonRightY = 190;

            listOfObstacles.Add(new Obstacle(150, 10, 4));
            listOfObstacles.Add(new Obstacle(500, 10, 4));
            listOfObstacles.Add(new Obstacle(275, 150, 200, 30));
            listOfObstacles.Add(new Obstacle(5, 150, 100, 30));
            listOfObstacles.Add(new Obstacle(623, 150, 100, 30));
            listOfObstacles.Add(new Obstacle(300, 340, 70, 240, "polygon"));
            listOfObstacles.Add(new Obstacle(400, 340, 618, 240, "polygon"));
            listOfObstacles.Add(new Obstacle(275, 250, 160, 30));

            listOfSmileys.Add(new Smiley(100, 15, 2));
            listOfSmileys.Add(new Smiley(355, 60, 3));
            listOfSmileys.Add(new Smiley(680, 15, 2));
            listOfSmileys.Add(new Smiley(350, 200, 4));
            listOfSmileys.Add(new Smiley(30, 275, 1));
            listOfSmileys.Add(new Smiley(677, 275, 4));
            listOfSmileys.Add(new Smiley(265, 355, 2));
            listOfSmileys.Add(new Smiley(435, 355, 2));

            listOfCanons.Add(new Canon(canonRightX, canonRightY, "right"));
            listOfCanons.Add(new Canon(canonDownX, canonDownY, "down"));
            listOfCanons.Add(new Canon(canonUpX, canonUpY, "up"));
            listOfCanons.Add(new Canon(canonLeftX, canonLeftY, "left"));
        }
        private void LevelThree()
        {
            canonDownX = 440;
            canonDownY = 0;

            canonUpX = 530;
            canonUpY = 404;

            canonLeftX = 620;
            canonLeftY = 110;

            canonRightX = 0;
            canonRightY = 160;


            listOfObstacles.Add(new Obstacle(500, 180, 200, 70, 50, 180));
            listOfObstacles.Add(new Obstacle(70, 180, 150, 100, 300, -180));
            listOfObstacles.Add(new Obstacle(400, 70, 3));
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
            listOfObstacles.Add(new Obstacle(220, 200, 200, 70, 50, -150));
            listOfObstacles.Add(new Obstacle(400, 310, 100, 30));
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 150));
            listOfObstacles.Add(new Obstacle(5, 110, 220, 20));

            listOfSmileys.Add(new Smiley(110, 80, 1));
            listOfSmileys.Add(new Smiley(450, 250, 1));
            listOfSmileys.Add(new Smiley(560, 213, 2));
            listOfSmileys.Add(new Smiley(510, 65, 1));
            listOfSmileys.Add(new Smiley(660, 75, 1));
            listOfSmileys.Add(new Smiley(660, 145, 2));
            listOfSmileys.Add(new Smiley(360, 65, 2));
            listOfSmileys.Add(new Smiley(130, 140, 1));
            listOfSmileys.Add(new Smiley(5, 40, 2));

            listOfCanons.Add(new Canon(canonRightX, canonRightY, "right"));
            listOfCanons.Add(new Canon(canonDownX, canonDownY, "down"));
            listOfCanons.Add(new Canon(canonUpX, canonUpY, "up"));
            listOfCanons.Add(new Canon(canonLeftX, canonLeftY, "left"));
        }

        private void LevelFour()
        {
            canonDownX = 5;
            canonDownY = 31;

            canonUpX = 508;
            canonUpY = 404;

            canonLeftX = 728;
            canonLeftY = 275;

            canonRightX = 56;
            canonRightY = 120;

            listOfObstacles.Add(new Obstacle(247, 157, 8));
            listOfObstacles.Add(new Obstacle(365, 261, 140, 35, 120, 276));
            listOfObstacles.Add(new Obstacle(190, 290, 238, 443, 144, 282, 205, 260));
            listOfObstacles.Add(new Obstacle(660, 50));
            listOfObstacles.Add(new Obstacle(530, 190, 640, 348, "polygon"));
            listOfObstacles.Add(new Obstacle(290, 0, 30, 100));
            listOfObstacles.Add(new Obstacle(325, 70, 160, 30));
            listOfObstacles.Add(new Obstacle(490, 80, 510, 60, "polygon"));
            listOfObstacles.Add(new Obstacle(155, 70, 130, 30));
            listOfObstacles.Add(new Obstacle(155, 40, 30, 25));
            listOfObstacles.Add(new Obstacle(50, 220, 15, 130));
            listOfObstacles.Add(new Obstacle(40, 120, 15, 20));

            listOfSmileys.Add(new Smiley(330, 30, 4));
            listOfSmileys.Add(new Smiley(610, 30, 4));
            listOfSmileys.Add(new Smiley(250, 30, 2));
            listOfSmileys.Add(new Smiley(205, 165, 2));
            listOfSmileys.Add(new Smiley(360, 165, 2));
            listOfSmileys.Add(new Smiley(630, 90, 1));
            listOfSmileys.Add(new Smiley(680, 360, 2));
            listOfSmileys.Add(new Smiley(450, 310, 4));
            listOfSmileys.Add(new Smiley(310, 253, 4));
            listOfSmileys.Add(new Smiley(215, 280, 3));
            listOfSmileys.Add(new Smiley(10, 290, 1));

            listOfCanons.Add(new Canon(canonRightX, canonRightY, "right"));
            listOfCanons.Add(new Canon(canonDownX, canonDownY, "down"));
            listOfCanons.Add(new Canon(canonUpX, canonUpY, "up"));
            listOfCanons.Add(new Canon(canonLeftX, canonLeftY, "left"));
        }
        private void LevelFive()
        {
            canonDownX = 700;
            canonDownY = 0;

            canonUpX = 670;
            canonUpY = 404;

            canonLeftX = 640;
            canonLeftY = 320;

            canonRightX = 311;
            canonRightY = 80;

            listOfObstacles.Add(new Obstacle(65, 5, 20, 326));
            listOfObstacles.Add(new Obstacle(65, 336, 20, 20));
            listOfObstacles.Add(new Obstacle(130, 5, 20, 140));
            listOfObstacles.Add(new Obstacle(130, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(130, 335, 20, 64));
            listOfObstacles.Add(new Obstacle(380, 5, 20, 64));
            listOfObstacles.Add(new Obstacle(440, 5, 20, 64));
            listOfObstacles.Add(new Obstacle(500, 5, 20, 64));
            listOfObstacles.Add(new Obstacle(560, 5, 20, 64));

            listOfObstacles.Add(new Obstacle(155, 50, 90, 20));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 110));
            listOfObstacles.Add(new Obstacle(200, 120, 400, 20));

            listOfObstacles.Add(new Obstacle(200, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(200, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(260, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(260, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(320, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(320, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(380, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(380, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(440, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(440, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(500, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(500, 335, 20, 64));

            listOfObstacles.Add(new Obstacle(560, 190, 20, 140));
            listOfObstacles.Add(new Obstacle(560, 335, 20, 20));

            listOfObstacles.Add(new Obstacle(640, 50, 20, 347));

            listOfSmileys.Add(new Smiley(160, 360, 1));
            listOfSmileys.Add(new Smiley(225, 360, 1));
            listOfSmileys.Add(new Smiley(285, 360, 1));
            listOfSmileys.Add(new Smiley(345, 360, 3));
            listOfSmileys.Add(new Smiley(405, 360, 1));
            listOfSmileys.Add(new Smiley(465, 360, 1));
            listOfSmileys.Add(new Smiley(590, 340, 3));
            listOfSmileys.Add(new Smiley(160, 15, 2));
            listOfSmileys.Add(new Smiley(690, 150, 2));
            listOfSmileys.Add(new Smiley(670, 260, 2));
            listOfSmileys.Add(new Smiley(690, 370, 4));

            listOfSmileys.Add(new Smiley(405, 15, 1));
            listOfSmileys.Add(new Smiley(465, 15, 1));
            listOfSmileys.Add(new Smiley(525, 15, 1));

            listOfSmileys.Add(new Smiley(330, 15, 4));


            listOfCanons.Add(new Canon(canonRightX, canonRightY, "right"));
            listOfCanons.Add(new Canon(canonDownX, canonDownY, "down"));
            listOfCanons.Add(new Canon(canonUpX, canonUpY, "up"));
            listOfCanons.Add(new Canon(canonLeftX, canonLeftY, "left"));
        }
    }
}
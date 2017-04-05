using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSC
{
    class Level
    {
        static List<GameObject> objects = new List<GameObject>();
        static List<GameObject> objectsAlt = new List<GameObject>();
        Graphics dc;
        DateTime endTime;
        float currentFps;
        BufferedGraphics backBuffer;
        Player player;
        int index = 0;
        int score = 0;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        static public List<GameObject> Objects
        {
            get { return objects; }
            set { objects = value; }
        }
         public int HighScore
        {
            get { return score; }
        }

        public Level(Graphics dc, Rectangle displayRectangle)
        {
            this.dc = dc;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
        }
        public void SetupLevel()
        {

            endTime = DateTime.Now;
            for (int i = 0; i < 2; i++)
            {
                objects.Add(new Background(@"Sprites/BackGroundFullSprite.png", new Vector2D(50, 0 + i * 705), 1, 0, 250));
            }
            objects.Add(new Wall(@"Sprites/BlankWall.png", new Vector2D(50, 0), 1, 1));
            objects.Add(new Wall(@"Sprites/BlankWall.png", new Vector2D(625, 0), 1, 1));
            player = new Player(500, @"Sprites/SantaJump.png", @"Sprites/SantaJumpInvert.png", new Vector2D(175, 100), 2, 1, false);
            objects.Add(player);
            for (int i = 0; i < 5; i++)
            {
                objects.Add(new Hazard(@"Sprites/SpikeBaseLeft.png", new Vector2D(175, 700 + i * 48), 1, 5, 250, player));
                objects.Add(new Hazard(@"Sprites/SpikeBaseRight.png", new Vector2D(576, 1000 + i * 48), 1, 5, 250, player));
            }
        }


        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;

            TimeSpan deltaTime = startTime - endTime;

            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;

            currentFps = 1000 / milliSeconds;


            Update(currentFps);
            UpdateAnimations(currentFps);
            Draw(dc);

            endTime = DateTime.Now;
            score++;
        }
        private void Draw(Graphics dc)
        {
            foreach (GameObject go in objects)
            {
                go.Draw(dc);
                Font f = new Font("Ariel", 20);
#if DEBUG
                dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.White, 0, 0);
                //  dc.DrawString(string.Format("Score: {0}", score), f, Brushes.LightBlue, 100, 400);

#endif

            }
            backBuffer.Render();
        }
        private void Update(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.Update(dc, fps);
            }
        }

        private void UpdateAnimations(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.UpdateAnimation(fps, 0);
                if (player.RightWall == true)
                {
                    index = 1;
                    player.UpdateAnimation(fps, index);
                }
                else
                {
                    index = 0;
                    player.UpdateAnimation(fps, index);
                }
            }
        }
    }
}

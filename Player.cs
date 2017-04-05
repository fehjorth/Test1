using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;

namespace SOSC
{
    class Player : GameObject
    {
        float speed;
        bool rightWall;
        bool isJumping = false;
        private float xDir;
   

        public bool IsJumping
        {
            get { return isJumping; }
            set { isJumping = value; }
        }

        public bool RightWall
        {
            get { return rightWall; }
            set { rightWall = value; }
        }

        public Player(float speed, string imagePath, Vector2D startPosition, float scaleFactor, float animationSpeed, bool rightWall) : base(imagePath, startPosition, scaleFactor, animationSpeed)
        {
            xDir = 1;
            this.speed = speed;
            base.position = startPosition;
            this.rightWall = rightWall;
        }

        public Player(float speed, string imagePath, string imagePath2, Vector2D startPosition, float scaleFactor, float animationSpeed, bool rightWall) : base(imagePath, imagePath2, startPosition, scaleFactor, animationSpeed)
        {
            xDir = 1;
            this.speed = speed;
            base.position = startPosition;
            this.rightWall = rightWall;
            animationFrames = new List<Image>();

            animationFrames.Add(Image.FromFile(imagePath));
            animationFrames.Add(Image.FromFile(imagePath2));
        }

        public override void Update(Graphics dc, float fps)
        {
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space) && !isJumping)
            {
                isJumping = true;
            }
             if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Escape))
            {
                
                Environment.Exit(0);
            }
            
            if (IsJumping)
            {
                Jump(fps);
            }
            base.Update(dc, fps);
            dc.Clear(Color.Black);
            
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Hazard)
            {
                Environment.Exit(0);
            }

        }

        public void Jump(float fps)
        {
            Position.X += xDir / fps * speed;
        }

        public override void OnCollisionEnter(GameObject item)
        {
            if (item is Wall)
              {
                isJumping = false;
                if (rightWall)
                {
                    rightWall = false;
                }
                else
                {
                    rightWall = true;
                }
                xDir *= -1;
            }
        }

        public override void UpdateAnimation(float fps, int index)
        {
            Sprite = animationFrames[index];
        }
    }
}

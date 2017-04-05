using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSC
{
    class Background : GameObject
    {
        float speed;

        public Background(string imagePath, Vector2D position, float scaleFactor, float animationSpeed, float speed) : base(imagePath, position, scaleFactor, animationSpeed)
        {
            this.speed = speed;
        }

        public override void Update(Graphics dc, float fps)
        {
            Vector2D velocity = Position - position;
            velocity.Normalize();

            position.Y -= 1 / fps * speed;

            if (Position.Y < -710)
            {
                Position.Y = 705;
            }

            base.Update(dc, fps);
        }
    }
}

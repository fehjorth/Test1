using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSC
{
    class Hazard : GameObject
    {
        int one 1;
        Player player;
        float speed;

        public Hazard(string imagePath, Vector2D position, float scaleFactor, float animationSpeed, float speed, Player player) : base(imagePath, position, scaleFactor, animationSpeed)
        {
            base.position = position;
            this.player = player;
            this.speed = speed;
        }

        public override void Update(Graphics dc, float fps)
        {
            Vector2D velocity = Position - position;
            velocity.Normalize();

            position.Y -= 1 / fps * speed;

            if (Position.Y < -40)
            {
                Position.Y = 701;
            }

            base.Update(dc, fps);
        }

        public override void OnCollision(GameObject entity)
        {
            if (entity is Player)
            {
                
            }
        }

        public override void OnCollisionEnter(GameObject item)
        {
            
        }
    }
}

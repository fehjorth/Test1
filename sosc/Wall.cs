using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSC
{
    class Wall : GameObject
    {
        public Wall(string imagePath, Vector2D position, float scaleFactor, float animationSpeed) : base(imagePath, position, scaleFactor, animationSpeed)
        {
            base.position = position;
        }
    }
}

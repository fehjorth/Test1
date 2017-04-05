using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSC
{
    class Vector2D
    {
        float x;
        float y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        private float Length()
        {
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public void Normalize()
        {
            float length = Length();

            x = x / length;
            y = y / length;
        }
    }
}

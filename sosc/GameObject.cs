using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SOSC
{
    abstract class GameObject
    {
        string tester;

        int one;
        protected Vector2D position;
        Image sprite;
        protected List<Image> animationFrames;
        protected float currentFrameIndex;
        float scaleFactor;
        float animationSpeed;
        private List<GameObject> collidingObjects = new List<GameObject>();

        public Image Sprite
        {
            set { sprite = value; }
        }

        public Vector2D Position
        {
            get { return position; }
        }

        public RectangleF CollisionBox
        {
            get { return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor); }
        }

        public GameObject(string imagePath, Vector2D startPosition, float scaleFactor, float animationSpeed)
        {
            string[] imagePaths = imagePath.Split(';');
            animationFrames = new List<Image>();

            this.scaleFactor = scaleFactor;
            position = startPosition;
            this.animationSpeed = animationSpeed;

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = animationFrames[0];
        }

        public GameObject(string imagePath, string imagePath2, Vector2D startPosition, float scaleFactor, float animationSpeed)
        {
            animationFrames = new List<Image>();
            this.scaleFactor = scaleFactor;
            position = startPosition;
            this.animationSpeed = animationSpeed;            

            animationFrames.Add(Image.FromFile(imagePath));
            animationFrames.Add(Image.FromFile(imagePath2));

            this.sprite = animationFrames[0];
        }

        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
#if DEBUG
            dc.DrawRectangle(new Pen(Brushes.White), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
#endif
        }

        public virtual void UpdateAnimation(float fps, int index)
        {
            sprite = animationFrames[index];
        }

        public virtual void Update(Graphics dc, float fps)
        {
            tester = "her derp";
            tester = "her derp 2";
            CheckCollision();
            one++;
        }

        private void CheckCollision()
        {
            foreach (GameObject item in Level.Objects)
            {
                if (item != this)
                {
                    if (IsCollidingWith(item))
                    {
                        if (!collidingObjects.Contains(item))
                        {
                            OnCollisionEnter(item);
                            collidingObjects.Add(item);
                        }

                        OnCollision(item);
                    }
                    else if (collidingObjects.Contains(item))
                    {
                        collidingObjects.Remove(item);
                    }
                }
            }
        }

        public bool IsCollidingWith(GameObject item)
        {
            return CollisionBox.IntersectsWith(item.CollisionBox);
        }

        public virtual void OnCollision(GameObject item)
        {

        }

        public virtual void OnCollisionEnter(GameObject item)
        {
            
        }
    }
}

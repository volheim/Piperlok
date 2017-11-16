using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    abstract class Actors
    {
#region Fields
        //Indicates that an actor is alive. Cameras who is not alive, stops working. Techzomies is not dangerous anymore and Piperlok and Milo is dying.
        public bool alive;
        protected float speed;
        protected int health;
        public string name;
        public float scaleFactor;
        Vector2D position;
        public Image sprite;
        public float gravityPull;
        float animationSpeed;
        //List of all frames in the animation
        protected List<Image> animationFrames;
        //Index used for running through the animations
        protected float currentFrameIndex = 5;
        public bool grounded;
#endregion

        public virtual void Update(float fps)
        {
            
            //Runs all GameObject's gamelogic
            CheckCollision();
        }

        //Actors constructor
        public Actors(string imagePath, float speed, Vector2D startposition, float scaleFactor, string name)
        {
            animationSpeed = 5;

            //Stores all paths in a array
            string[] imagePaths = imagePath.Split(';');

            //Sets the position as startposition
            this.position = startposition;

            //Instantiates the list of animations
            this.animationFrames = new List<Image>();

            //Adds all images to the list
            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }

            //Selects a default sprite
            this.sprite = this.animationFrames[0];
            this.gravityPull = 2f;
            this.scaleFactor = scaleFactor;

        }

        public virtual void Gravity()
        {
        }

        public virtual void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
        }

        //Updates the animation
        public void UpdateAnimations(float fps)
        {
            //Calculates the factor to make the animation framerate independent
            float factor = 1 / fps;

            //Calculates the current index
            currentFrameIndex += factor * animationSpeed;

            //Checks if we need to reset the animation
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }

            //Changes the sprite
            sprite = animationFrames[(int)currentFrameIndex];

        }

        //Property for returning a collision rectangle with the correct size and position
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
            }
            set { CollisionBox = value;}
        }

        //Returns true, if the GameObject is colliding with the other GameObject
        //Uses intersectswith to determine if a collision is taking place 
        public bool IsCollidingWith(Actors other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        public bool IsCollidingWith(Objects other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        public virtual void IsnotGrounded() {
        }
        //This method is called whenever a collision happens
        public abstract void OnCollision(Actors other);
        public abstract void OnCollision(Objects other);

        protected virtual void CheckCollision()
        {
            //Runs through all objects in the GameWorld
            foreach (Actors go in GameWorld.ActorList)
            {
                //If the Actors we are checking isn't itself
                //This prevents them from colliding with itself
                if (go != this)
                {
                    //If this object is colliding with the other object
                    //Then we have a collision
                    if (this.IsCollidingWith(go))
                    {
                        //a collision has happend
                        OnCollision(go);
                    }
                }

            }
            int gravityProc = 0;
            foreach (Objects go in GameWorld.objList)
            {

                if (this.IsCollidingWith(go))
                {
                    OnCollision(go);
                    gravityProc++;
                }
            }

            foreach(Actors a in GameWorld.actorList)
            {
                if (a is Piperlok)
                {
                    if (a.grounded = false && gravityProc <= 0)
                    {
                        a.IsnotGrounded();
                    }
                }
            }
 
        }
    }
}

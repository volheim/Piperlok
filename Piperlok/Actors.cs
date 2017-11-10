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
        //bruges til at indikere om en actor er aktiv. kameraer som ikke er alive stopper, zombier er ikke længere farlige, piperlok og Milo MacDonald dør
        public bool alive;
        public float speed;
        public int health;
        public string name;
        

<<<<<<< HEAD

        Vector2D position;

=======
        public PointF position;
>>>>>>> origin/Skywalker
        public Image sprite;

        public float gravityPull;

        float animationSpeed;
        protected List<Image> animationFrames;
        protected float currentFrameIndex = 5;


        public virtual void Update(float fps)
        {

        }
        
<<<<<<< HEAD

        public Actors(float speed, string imagePath, Vector2D startposition)
        {
            animationSpeed = 5;
            string[] imagePaths = imagePath.Split(';');
            this.position = startposition;
            this.animationFrames = new List<Image>();

=======
        public Actors(float speed, string imagePath, PointF startposition)
        {
            animationSpeed = 5;
            string[] imagePaths = imagePath.Split(';');
            this.position = startposition;
            this.animationFrames = new List<Image>();

>>>>>>> origin/Skywalker
            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            this.sprite = this.animationFrames[0];
        }

        public virtual void Collide()
        {

        }

        public virtual void Gravity()
        {
            
            
        }

        public void Draw(Graphics dc)
        {
<<<<<<< HEAD

=======
>>>>>>> origin/Skywalker
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width, sprite.Height);
        }

        public void UpdateAnimations(float fps)
        {
            float factor = 1 / fps;
            currentFrameIndex += factor * animationSpeed;
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }
            sprite = animationFrames[(int)currentFrameIndex];

        }
    }
}

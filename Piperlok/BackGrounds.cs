using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class BackGrounds
    {
        Vector2D position;
        Image sprite;
        private List<Image> backGround;

        float animationSpeed;

        //Index used for running through the animations
        protected float currentFrameIndex;

        public BackGrounds(string imagePath, Vector2D position)
        {
            string[] imagePaths = imagePath.Split(';');
            this.position = position;
            this.backGround = new List<Image>();

            animationSpeed = 7;

            foreach (string path in imagePaths)
            {
                backGround.Add(Image.FromFile(path));
            }
            this.sprite = this.backGround[0];
        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width*3, sprite.Height*3);
            UpdateAnimations(45f);
        }

        public Vector2D Position
        {
            get { return this.position; }
        }
        public void UpdateAnimations(float fps)
        {
            //Calculates the factor to make the animation framerate independent
            float factor = 1 / fps;

            //Calculates the current index
            currentFrameIndex += factor * animationSpeed;

            //Checks if we need to reset the animation
            if (currentFrameIndex >= backGround.Count)
            {
                currentFrameIndex = 0;
            }

            //Changes the sprite
            sprite = backGround[(int)currentFrameIndex];

        }





    }
}

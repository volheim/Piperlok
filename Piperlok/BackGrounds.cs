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
        float scaleFactor;
        

        public BackGrounds(string imagePath, Vector2D startposition,float scaleFactor)
        {
            string[] imagePaths = imagePath.Split(';');
            this.position = startposition;
            this.backGround = new List<Image>();
            this.scaleFactor = scaleFactor;

            this.sprite = Image.FromFile(imagePath);

            
        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width*scaleFactor, sprite.Height*scaleFactor);
        }

        public Vector2D Position
        {
            get { return this.position; }
        }





    }
}

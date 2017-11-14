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
        
        

        public BackGrounds(string imagepath, Vector2D startposition)
        {
            string[] imagePaths = imagepath.Split(';');
            this.position = startposition;
            this.backGround = new List<Image>();

            foreach (string path in imagePaths)
            {
                backGround.Add(Image.FromFile(path));
            }
            this.sprite = this.backGround[0];
        }

        public void Draw(Graphics dc)
        {
            dc.DrawImage(sprite, position.X, position.Y, sprite.Width*2, sprite.Height*2);
        }

        public Vector2D Position
        {
            get { return this.position; }
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Piperlok
{
    class Piperlok : Actors
    {
        float jumpHeight;
        float jumpHeightLeft;
        float jumpTime;

        public RectangleF collisionBox;

<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        Vector2D position;
>>>>>>> origin/ReBrachingMikkel

        bool grounded = true;

<<<<<<< HEAD
        public Piperlok(string imagePaths, float speed, int health, PointF startPosition) : base(speed, imagePaths, startPosition)
        {
            name = "Piperlok";
            //skab en sprite og collision box til piperlok

=======
        public Piperlok(string imagePaths, float speed, int health, Vector2D startposition) : base(speed, imagePaths, startposition)
        {
            name = "Piperlok";
            //skab en sprite og collision box til piperlok
            position = startposition;
>>>>>>> origin/ReBrachingMikkel
=======
        Vector2D position;

        bool grounded = true;

        public Piperlok(string imagePaths, float speed, int health, Vector2D startposition) : base(speed, imagePaths, startposition)
        {
            name = "Piperlok";
            //skab en sprite og collision box til piperlok
            position = startposition;
>>>>>>> 23872359dd5181df5f022fc9378fc945d816f658

            /*Graphics sprite = Graphics.FromImage(@"imagePaths");
            collisionBox.Height = piperlokSprite.Height;
            collisionBox.Width = piperlokSprite.Width;*/

            //sætter piperlok i midten af skærmen
        }

        public override void Update(float fps)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
            
>>>>>>> origin/ReBrachingMikkel
=======
            
>>>>>>> 23872359dd5181df5f022fc9378fc945d816f658
            Gravity();
            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += ((1 / fps) * 150);
            }
            if (Keyboard.IsKeyDown(System.Windows.Forms.Keys.Space) && grounded || Keyboard.IsKeyDown(Keys.W) && grounded)
            {
                Jump();
            }
        }

        public void Jump()
        {
            grounded = false;
            jumpHeightLeft = jumpHeight;
            Gravity();
        }

        public override void Collide()
        {
            base.Collide();
        }

        //bruges til at interagere med nogle objekter, starter minigames
        public void Hack()
        {

        }

        //flytter på objekter som er defineret som moveable
        public void PushPull()
        {

        }

        public override void Gravity()
        {
            base.Gravity();

            //udregner hoppet som en fysisk bevægelse, hoppet bliver langsommere
            float netMove;
            netMove = (jumpHeightLeft - gravityPull) * Form1.currentFps;
            jumpHeightLeft =-gravityPull * Form1.currentFps;

            //sætter en terminal velocity
            if(netMove < -2) { netMove = -2; }
            position.Y += netMove * Form1.currentFps;

            
        }
    }
}

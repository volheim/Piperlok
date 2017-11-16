using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Piperlok
{
    class TechZombie : Actors
    {
        Vector2D position;

        int damage;

        public TechZombie(string imagePaths, float speed, int health, Vector2D startPosition, float scaleFactor, string name, int damage) : base(imagePaths,speed, startPosition, scaleFactor, name)
        {
            this.damage = damage;
            this.health = health;
            position = startPosition;
            position.Y = startPosition.Y - (this.sprite.Height * scaleFactor);
        }

        public override void Update(float fps)
        {
            if(health == 0)
            {
                ZombieDeath(this);
            }
            base.Update(fps);
        }

        void ZombieDeath(TechZombie zomb)
        {
            zomb.damage = 0;
            zomb.sprite = Image.FromFile(@"Sprites\ZombieAnim\zombie_08.png");
        }

        public override void Gravity()
        {
            base.Gravity();
        }

        public override void OnCollision(Actors other)
        {
            if(other is Piperlok)
            {
                if (Piperlok.invincible == false) {
                    Piperlok.invincible = true;
                    other.health -= damage;
                }
                //The "enemy" is colliding with Piperlok
            }
        }

        public override void OnCollision(Objects other)
        {
            //throw new NotImplementedException();
        }
    }
}

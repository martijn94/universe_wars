using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    public abstract class Bullet : DrawableGameComponent, IBulletBehaviour
    {

        public Vector2 position { get; set; }
        public Texture2D texture { get; set; }

        public int bulletPower { get; set; }

        public IBulletBehaviour bulletBehaviour { get; set; }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height
                    );
            }

        }

        public Bullet(Game game)
            : base(game)
        {
            

        }

        public virtual void move()
        {
            bulletBehaviour.move();

        }

        public Boolean onScreen()
        {
            return position.Y < 0;
        }


        


        






    }
}

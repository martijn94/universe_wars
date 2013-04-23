using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class StandardBombMove : IBulletBehaviour
    {
        public Bullet bullet { get; set; }



        public StandardBombMove(Bullet b)
        {
            bullet = b;
        }

        public void move()
        {
            float posX = bullet.position.X;
            float posY = bullet.position.Y;

            posY += 3;
            
            bullet.position = new Vector2(posX, posY);



        }
    }
}

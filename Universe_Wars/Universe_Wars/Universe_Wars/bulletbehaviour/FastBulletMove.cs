using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

/// <summary>
/// Dit is de fastbullet move, 
/// </summary>

namespace Universe_Wars
{
    class FastBulletMove : IBulletBehaviour
    {
        public Bullet bullet { get; set; }

        public FastBulletMove(Bullet b)
        {
            bullet = b;
        }

        public void move()
        {
            float posX = bullet.position.X;
            float posY = bullet.position.Y;

            posY -= 10;

            bullet.position = new Vector2(posX, posY);



        }
    }
}

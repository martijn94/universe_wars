using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class SearchBulletMove : IBulletBehaviour
    {
        public Bullet bullet { get; set; }

        private Enemy enemy;

        private int xSpeed = 0;
        private int ySpeed = -5;


        GameEngine gameEngine = GameEngine.getInstance();

        public SearchBulletMove(Bullet b)
        {
            bullet = b;

            
            enemy = gameEngine.getRandomEnemy();
           
        }

        public void move()
        {
            float posX = bullet.position.X;
            float posY = bullet.position.Y;

          
            if (enemy != null)
            {
                if (bullet.position.Y < enemy.position.Y)
                {
                    xSpeed = 0;
                    ySpeed = -5;

                }
                else
                {
                    if (bullet.position.X > enemy.position.X)
                    {
                        xSpeed = -5;
                    }
                    else if (bullet.position.X < enemy.position.X)
                    {
                        xSpeed = +5;
                    }
                    if (bullet.position.Y > enemy.position.Y)
                    {
                        ySpeed = -5;
                    }
                }

              
            }

            
            
            bullet.position = new Vector2(posX + xSpeed, posY + ySpeed); 

           
        }
    }
}

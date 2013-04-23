using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Universe_Wars
{
    class FlyChure : IFlyBehaviour
    {
        
        private Enemy enemy;
        private int xSpeed = 5;
        private int ySpeed = 0;

        public FlyChure(Enemy e)
        {
            if (enemy == null)
            {
                enemy = e;
            }
        }

        public void fly()
        {
            Vector2 curpos = enemy.position;
            
            

            if (enemy.position.X > enemy.Game.GraphicsDevice.Viewport.Width - enemy.texture.Width)
            {
                xSpeed = xSpeed * -1;
                ySpeed = ySpeed + 51;
                
            }
            else
            {
                ySpeed = 0;
            }

            if (enemy.position.X < 0 )
            {
                xSpeed = xSpeed * -1;
                ySpeed = ySpeed + 51;
                

            }

            enemy.position = new Vector2(curpos.X + xSpeed, curpos.Y + ySpeed);
            

            //System.Diagnostics.Debug.WriteLine("CHURE");


        }
    }
}

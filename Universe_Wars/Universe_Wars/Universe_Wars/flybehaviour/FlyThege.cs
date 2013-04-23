using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class FlyThege : IFlyBehaviour
    {
        private Enemy enemy;
        private int xSpeed = 5;
        private int ySpeed = 1;

        public FlyThege(Enemy e)
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
            }
            else
            {
                ySpeed = 1;
            }
            if (enemy.position.X <= 0)
            {
                xSpeed = xSpeed * -1;
            }
            
            enemy.position = new Vector2(curpos.X + xSpeed, curpos.Y + ySpeed);

            //System.Diagnostics.Debug.WriteLine("THEGE");


        }
    }
}

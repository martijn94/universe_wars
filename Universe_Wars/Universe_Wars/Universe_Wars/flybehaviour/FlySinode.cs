using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class FlySinode : IFlyBehaviour
    {
        private Enemy enemy;

        private double sinusIndex = 0;

        private double lastOffSet = 0;

        private float ySpeed = 0.5f;

        public FlySinode(Enemy e)
        {
            if (enemy == null)
            {
                enemy = e;
            }
        }

        public void fly()
        {
            sinusIndex = sinusIndex + 0.1;

            double newOffSet = Math.Sin(sinusIndex) * 50;

            enemy.position =
                new Vector2((float)(enemy.position.X - lastOffSet + newOffSet),
                    enemy.position.Y + ySpeed);

            lastOffSet = newOffSet;

            if (enemy.position.Y > enemy.Game.GraphicsDevice.Viewport.Height - enemy.texture.Height || enemy.position.Y < 0)
            {
                ySpeed = ySpeed * -1;

            }


            //System.Diagnostics.Debug.WriteLine("SINODE");


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class ShootStandard : IShootBehaviour
    {
        public Game _game;

        private int counter = 0;

        private GameEngine gameEngine;

        public ShootStandard(Game game)
        {
            _game = game;
            gameEngine = GameEngine.getInstance();
        }

        public Game getGame()
        {
            return _game;
        }

        public void shoot()
        {
            if (counter++ % 12 == 0)
            {
                Vector2 playerPos = Game1.spaceship.position;

                Bullet newBullet = new BulletStandard(_game);
                _game.Components.Add(newBullet);
                gameEngine.addBullet(newBullet);
                

            }
           
        }
    }
}

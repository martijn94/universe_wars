using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class GuidedMissleGunDecorator : IShootBehaviour
    {
        private IShootBehaviour shootBehaviour;
        private int count = 0;

        public Game _game;

        public GuidedMissleGunDecorator(IShootBehaviour g)
        {
            _game = g.getGame();
            shootBehaviour = g;
        }

        public Game getGame()
        {
            return _game;
        }


        public void shoot()
        {
            if (count++ % 120 == 0)
            {
                Vector2 playerPos = Game1.spaceship.position;


                Bullet newBullet = new BulletGuidedMissle(_game);
                _game.Components.Add(newBullet);

                GameEngine gameEngine = GameEngine.getInstance();
                gameEngine.addBullet(newBullet);
                

            }
            shootBehaviour.shoot();
        }
    }
}

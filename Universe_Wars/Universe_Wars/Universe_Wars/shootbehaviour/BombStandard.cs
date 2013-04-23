using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace Universe_Wars
{
    class BombStandard : IShootBehaviour
    {
        public Game _game;

        private GameEngine gameEngine;

        public BombStandard(Game game)
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
                Bullet newBullet = new EnemyBomb(_game);
                _game.Components.Add(newBullet);
                gameEngine.bombList.Add(newBullet);
        }
    }
}

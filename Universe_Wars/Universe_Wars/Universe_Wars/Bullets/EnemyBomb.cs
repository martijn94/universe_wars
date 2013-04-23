using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Universe_Wars
{
    public class EnemyBomb : Bullet
    {

        private GameEngine gameEngine;

        public EnemyBomb(Game game)
            : base(game)
        {
            bulletBehaviour = new StandardBombMove(this);

            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.bomb];
            }


            gameEngine = GameEngine.getInstance();

            bulletPower = 20;
        }
        public override void Initialize()
        {
            //float posX = gameEngine.getRandomChure().position.X;
            //float posY = gameEngine.getRandomChure().position.Y;

           // position = new Vector2(posX, posY);
            position = gameEngine.getRandomChure().position;

            base.Initialize();
            
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            move();
            
            base.Update(gameTime);
            
            
            
        }


        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(gameTime);
        }
    }
}

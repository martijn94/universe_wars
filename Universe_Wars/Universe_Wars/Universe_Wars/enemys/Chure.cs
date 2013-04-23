using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Universe_Wars
{
    class Chure : Enemy
    {
        public IShootBehaviour shootBehaviour { get; set; }

        private static Game _game;

        private int counter = 0;

        GameEngine gameEngine = GameEngine.getInstance();
        

        public Chure(Game game)
            : base(game)
        {
            _game = game;
            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.chure];
            }

            setFlyBehaviour(new FlyChure(this));
        }

        public override void Initialize()
        {
            shootBehaviour = new BombStandard(_game);
            position = new Vector2(350, 20);
            gameEngine.chureList.Add(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            fly();
            if (counter++ % 1000 == 0)
            {
                shootBehaviour.shoot();
            }
            base.Update(gameTime);
            
            
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(gameTime);
        }

    }
}

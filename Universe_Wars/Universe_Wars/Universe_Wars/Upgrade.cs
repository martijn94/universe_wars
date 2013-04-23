using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    class Upgrade : DrawableGameComponent
    {

        public Vector2 position { get; set; }
        public Texture2D texture { get; set; }
        GameEngine gameEngine = GameEngine.getInstance();
        private static Game _game;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width,
                    texture.Height
                    );
            }

        }

        public Upgrade(Game game)
            : base(game)
        {
            _game = game;
            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.upgrade];
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            position = new Vector2(Game1.spaceship.position.X, 200);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            position = new Vector2(position.X, position.Y + 1);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(gameTime);
        }

        public Boolean onScreen()
        {
            return position.Y > Game.GraphicsDevice.Viewport.Height;
        }
    }
}

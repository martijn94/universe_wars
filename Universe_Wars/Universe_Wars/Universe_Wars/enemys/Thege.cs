using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    class Thege : Enemy
    {
        


        public Thege(Game game)
            : base(game)
        {
            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.thege];
            }

            setFlyBehaviour(new FlyThege(this));


        }

        public override void Initialize()
        {
            Random random = new Random();
            position = new Vector2(random.Next(500) + 20, 20);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            fly();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(gameTime);
        }

    }
}

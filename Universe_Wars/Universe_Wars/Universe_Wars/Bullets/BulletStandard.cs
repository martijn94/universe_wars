using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    public class BulletStandard : Bullet
    {
        public BulletStandard(Game game)
            : base(game)
        {
            bulletBehaviour = new StandardBulletMove(this);

            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.bullet];
            }

            bulletPower = 10;
        }
        public override void Initialize()
        {
            position = new Vector2(Game1.spaceship.position.X + Game1.spaceship.texture.Width/2 - 7, 400);
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

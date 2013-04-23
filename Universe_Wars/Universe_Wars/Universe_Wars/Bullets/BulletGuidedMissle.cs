using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    public class BulletGuidedMissle : Bullet
    {
        public BulletGuidedMissle(Game game)
            : base(game)
        {
            bulletBehaviour = new SearchBulletMove(this);

            //singleton pattern
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.guidedMissle];
            }

            bulletPower = 40;
        }
        public override void Initialize()
        {
            position = new Vector2(Game1.spaceship.position.X + Game1.spaceship.texture.Width / 2 - 15, 400);
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

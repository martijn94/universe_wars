using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Universe_Wars
{
    abstract class Enemy : DrawableGameComponent, IFlyBehaviour
    {
        public Vector2 position { get; set; }
        public Texture2D texture { get; set; }

        public IFlyBehaviour flybehaviour { get; set; }

        public int HitPoints { get; set; }

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

        public Enemy(Game game)
            : base(game)
        {
            HitPoints = 100;

        }

        public void setFlyBehaviour(IFlyBehaviour flystrategy)
        {
            flybehaviour = flystrategy;
        }

        public void fly()
        {
            flybehaviour.fly();
        }

        public Boolean onScreen()
        {
            return position.Y > Game.GraphicsDevice.Viewport.Height;
        }

    }
}

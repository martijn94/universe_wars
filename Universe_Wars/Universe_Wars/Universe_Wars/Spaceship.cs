using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Universe_Wars
{
    public class Spaceship : DrawableGameComponent
    {
        //Maak ruimte voor de game.
        private static Game _game;
        //Maak ruimte voor de positie.
        public Vector2 position { get; set; }
        //maak ruimte voor de texture.
        public Texture2D texture { get; set; }

        //Laad de gameengine in.
        GameEngine gameEngine = GameEngine.getInstance();

        //Maak een shootbehaviour aan(STRATEGY/DECORATOR PATTERN).
        public IShootBehaviour shootBehaviour { get; set; }

        //Zet de speed op 10;
        private int xSpeed = 10;

        //Zet de boundingbox voor spaceship(player).
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

        //Spaceship constructor.
        public Spaceship(Game game)
            : base(game)
        {
            _game = game;

            //Kijk of texture niet al bestaalt(SINGLETON PATTERN).
            if (texture == null)
            {
                texture = ContentManager.Textures[ContentManager.TextureFiles.spaceship];
            }
        }

        public override void Initialize()
        {
            //Zet het schieten op alleen standaard schieten(STRATEGY/DECORATOR pattern).
            shootBehaviour = new ShootStandard(_game);

            //Zet de startpositie voor spaceship.
            position = new Vector2(_game.GraphicsDevice.Viewport.Width/2 - texture.Width/2, 400);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {          
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            //Haal de keyboardstate op.
            KeyboardState k = Keyboard.GetState();

            //Als pijltje links is ingedrukt.
            if (k.IsKeyDown(Keys.Left))
            {
                //Laat spaceship naar links gaan.
                float newXPos = position.X - xSpeed;

                //Clamp de positie van het spaceship binnen het scherm.
                newXPos = MathHelper.Clamp(newXPos, 0, Game.GraphicsDevice.Viewport.Width - 64);

                //Zet de nieuwe positie van het spaceship.
                position = new Vector2(newXPos, position.Y);
            }

            //als pijltje rechts is ingedrukt.
            if (k.IsKeyDown(Keys.Right))
            {
                //laat het spaceship naar rechts gaan.
                float newXPos = position.X + xSpeed;

                //Clamp de positie van het spaceship binnen het scherm.
                newXPos = MathHelper.Clamp(newXPos, 0, Game.GraphicsDevice.Viewport.Width - 64);

                //Zet de nieuwe positie van het spaceship.
                position = new Vector2(newXPos, position.Y);
            }

            //Schiet wanneer er enemy's zijn.
            if(gameEngine.enemyList.Count > 0)
            {
                //Laat het spaceship schieten(via shootbehaviour)
                shootBehaviour.shoot();
            }         
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Teken het spaceship.
            Game1.spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            base.Draw(gameTime);
        }

        //Upgrade functie om de gun op te voeren(STRATEGY/DECORATOR PATTERN).
        public void upgrade(int i)
        {
            if (i == 0)
            {
                shootBehaviour = new ShootStandard(_game);
            }
            else if (i == 1)
            {
                shootBehaviour = new LaserGunDecorator(new ShootStandard(_game));
            }
            else if (i == 2)
            {
                shootBehaviour = new LaserGunDecorator(new MissleGunDecorator(new ShootStandard(_game)));
            }
            else if (i == 3)
            {
                shootBehaviour = new LaserGunDecorator(new MissleGunDecorator(new GuidedMissleGunDecorator(new ShootStandard(_game))));
            }
            else if (i > 3)
            {
                shootBehaviour = new LaserGunDecorator(new MissleGunDecorator(new GuidedMissleGunDecorator(new ShootStandard(_game))));
            }
        }
    }
}

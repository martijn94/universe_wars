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

namespace Universe_Wars
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public static SpriteBatch spriteBatch;

        public static Spaceship spaceship;

        private SpriteFont font;
        private SpriteFont bigFont;

        private GameEngine gameEngine;

        //Maak random om een random getal op te kunnen roepen.
        public static Random random = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Laad de content uit de content mananger.
            ContentManager.LoadContent(this);

            //Laad de gameengine in.
            gameEngine = GameEngine.getInstance();
            GameEngine.initialize(this);

            //Laads spaceship in.
            spaceship = new Spaceship(this);
            Components.Add(spaceship);

            //start level 1
            gameEngine.level1();
 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Voeg font toe.
            if (font == null)
            {
                font = ContentManager.Fonts[ContentManager.FontFiles.font];
            }
            //voeg bigfont toe
            if (bigFont == null)
            {
                bigFont = ContentManager.Fonts[ContentManager.FontFiles.bigFont];
            }
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Voer de update optie van de gameengine constant uit.
            gameEngine.update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin();

            //Teken verschillende teksten op het scherm.
            spriteBatch.DrawString(font, "Current level: " + gameEngine.currentLevel, new Vector2(20, 20), Color.White);
            spriteBatch.DrawString(font, "Lives: " + gameEngine.lives, new Vector2(20, 40), Color.Red);
            spriteBatch.DrawString(font, "Score: " + gameEngine.score, new Vector2(20, 60), Color.Blue);
            spriteBatch.DrawString(font, "Bullet hits: " + gameEngine.bulletHits, new Vector2(20, 80), Color.Green);
            spriteBatch.DrawString(font, "Number of upgrades: " + gameEngine.upgraded, new Vector2(20, 100), Color.Purple);
            spriteBatch.DrawString(bigFont, " " + gameEngine.gameText, new Vector2(10, 200), Color.White);

            
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}

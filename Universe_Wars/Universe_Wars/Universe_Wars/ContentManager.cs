using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Universe_Wars
{
    static class ContentManager
    {
        public enum TextureFiles
        {
            spaceship,
            sinode,
            chure,
            thege,
            bullet,
            laser,
            missle,
            guidedMissle,
            bomb,
            upgrade
        }

        public enum FontFiles
        {
            font,
            bigFont
        }

        //Maak een dictionary voor de textures.
        public static Dictionary<TextureFiles, Texture2D> Textures { get; set; }
        public static Dictionary<FontFiles, SpriteFont> Fonts { get; set; }

        public static void LoadContent(Game game)
        {
            //Maak nieuwe dictionary in Textures.
            Textures = new Dictionary<TextureFiles, Texture2D>();

            //laad alle texture files in.
            Textures.Add(TextureFiles.spaceship, game.Content.Load<Texture2D>("spaceship"));
            Textures.Add(TextureFiles.sinode, game.Content.Load<Texture2D>("sinode"));
            Textures.Add(TextureFiles.chure, game.Content.Load<Texture2D>("chure"));
            Textures.Add(TextureFiles.thege, game.Content.Load<Texture2D>("thege"));
            Textures.Add(TextureFiles.bullet, game.Content.Load<Texture2D>("bullet"));
            Textures.Add(TextureFiles.laser, game.Content.Load<Texture2D>("laser"));
            Textures.Add(TextureFiles.guidedMissle, game.Content.Load<Texture2D>("guidedMissle"));
            Textures.Add(TextureFiles.missle, game.Content.Load<Texture2D>("missle"));
            Textures.Add(TextureFiles.bomb, game.Content.Load<Texture2D>("bomb"));
            Textures.Add(TextureFiles.upgrade, game.Content.Load<Texture2D>("upgrade"));

            //Maak nieuwe dictionary in Fonts.
            Fonts = new Dictionary<FontFiles, SpriteFont>();

            //laad alle texture files in.
            Fonts.Add(FontFiles.font, game.Content.Load<SpriteFont>("font"));
            Fonts.Add(FontFiles.bigFont, game.Content.Load<SpriteFont>("bigFont"));
        }
    }
}

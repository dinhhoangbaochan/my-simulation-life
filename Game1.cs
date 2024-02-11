using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MySimulationLife
{
    public class Game1 : Game
    {
        Texture2D characterTexture;
        Vector2 characterPosition;

        int screenWidth;
        int screenHeight;

        int centerX;
        int centerY;

        int characterWidth;
        int characterHeight;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            centerX = (screenWidth / 2) - (characterWidth / 2);
            centerY = (screenHeight / 2) - (characterHeight / 2);

            characterPosition = new Vector2(centerX, centerY);

            Debug.WriteLine("Screen info " + screenWidth + " " + screenHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            characterTexture = Content.Load<Texture2D>("char");
            characterWidth = characterTexture.Width;
            characterHeight = characterTexture.Height;

            Debug.WriteLine("Character Texture info " + characterTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if ( mouseState.LeftButton == ButtonState.Pressed )
            {
                int x = 0;
                Debug.WriteLine("Current position of char: " + characterPosition);
                Debug.WriteLine("Current clicked position: " + mouseState.Position);
            }

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            _spriteBatch.Begin();
            _spriteBatch.Draw(characterTexture, characterPosition, Color.White );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
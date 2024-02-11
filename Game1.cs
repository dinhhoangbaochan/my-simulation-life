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
        Vector2? targetPosition;

        float movingSpeed = 100; // Moving speed of the object

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            characterTexture = Content.Load<Texture2D>("char");

            characterWidth = characterTexture.Width;
            characterHeight = characterTexture.Height;
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if ( mouseState.LeftButton == ButtonState.Pressed )
            {
                targetPosition = new Vector2(mouseState.X, mouseState.Y);
            }

            if ( targetPosition.HasValue )
            {
                Vector2 direction = targetPosition.Value - characterPosition;
                
                if ( direction.Length() > 1 )
                {
                    direction.Normalize();
                    characterPosition += direction * movingSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    targetPosition = null;
                }
                //Debug.WriteLine("Direction " + direction);
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
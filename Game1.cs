using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest
{
    public class Game1 : Game
    {
        Texture2D character;
        Vector2 characterPosition;
        float characterSpeed;

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
            characterPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            characterSpeed = 50f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            character = Content.Load<Texture2D>("je");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var KeyState = Keyboard.GetState();

            if(KeyState.IsKeyDown(Keys.W))
                characterPosition.Y -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(KeyState.IsKeyDown(Keys.S))
                characterPosition.Y += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(KeyState.IsKeyDown(Keys.A))
                characterPosition.X -= characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(KeyState.IsKeyDown(Keys.D))
                characterPosition.X += characterSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(characterPosition.X > _graphics.PreferredBackBufferWidth - character.Width / 2)
                characterPosition.X = _graphics.PreferredBackBufferWidth - character.Width / 2;
            else if(characterPosition.X < character.Width / 2)
                characterPosition.X = character.Width / 2;
            if(characterPosition.Y > _graphics.PreferredBackBufferHeight - character.Height / 2)
                characterPosition.Y = _graphics.PreferredBackBufferHeight - character.Height / 2;
            else if(characterPosition.Y < character.Height / 2)
                characterPosition.Y = character.Height / 2;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(character, characterPosition, null, Color.White, 0f, new Vector2(character.Width / 2, character.Height / 2),Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

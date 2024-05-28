using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PingPong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;
        Paddle paddle;
        Paddle paddle2;
        Ball ball;
        SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Globals.WIDTH;
            _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            paddle = new Paddle(false);
            paddle2 = new Paddle(true);
            ball = new Ball();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData<Color>(new Color[] { Color.White });
            font = Content.Load<SpriteFont>("Fonts/Score");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            paddle.Update(gameTime);
            paddle2.Update(gameTime);
            ball.Update(gameTime, paddle, paddle2);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.DrawString(font, Globals.player1_score.ToString(), new Vector2((Globals.WIDTH / 100) * 20, (Globals.HEIGHT / 100) * 20), Color.White);
            Globals.spriteBatch.DrawString(font, Globals.player2_score.ToString(), new Vector2((Globals.WIDTH / 100) * 80, (Globals.HEIGHT / 100) * 20), Color.White);

            paddle.Draw();
            paddle2.Draw();
            ball.Draw();

            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

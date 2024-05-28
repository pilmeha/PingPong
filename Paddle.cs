﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PingPong
{
    internal class Paddle
    {
        public Rectangle rect;
        float moveSpeed = 500f;
        bool isSecondPlayer;

        public Paddle(bool isSecondPlayer)
        {
            this.isSecondPlayer = isSecondPlayer;
            rect = new Rectangle((this.isSecondPlayer ? Globals.WIDTH - 40 : 0), 140, 40, 200);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if ((this.isSecondPlayer ? kstate.IsKeyDown(Keys.Up) : kstate.IsKeyDown(Keys.W)) && rect.Y > 0)
            {
                rect.Y -= (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if ((this.isSecondPlayer ? kstate.IsKeyDown(Keys.Down) : kstate.IsKeyDown(Keys.S)) && rect.Y < Globals.HEIGHT - rect.Height)
            {
                rect.Y += (int)(moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
        }
    }
}

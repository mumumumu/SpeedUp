using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

namespace speedup
{
    class EndScreen : Screen
    {
        public EndScreen()
        {
            State = ScreenState.Active;
        }

        public override void Draw()
        {
            base.Draw();

            ScreenManager.SpriteBatch.End();
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw( backgroundTexture, new Rectangle( 0, 0, ScreenManager.GraphicsDevice.Viewport.Width, ScreenManager.GraphicsDevice.Viewport.Height ), Color.White );
            ScreenManager.SpriteBatch.End();
            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "YOU WIN", new Vector2( 400, 400 ), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0 );
        }
    }
}

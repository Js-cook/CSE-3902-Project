using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Sprites
{
    public class RightMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(34, 10, 16, 17);

        public RightMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            currentFrame = currentFrame == sourceRectangle1 ? sourceRectangle2 : sourceRectangle1;
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }

    public class LeftMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(34, 10, 16, 17);

        public LeftMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            currentFrame = currentFrame == sourceRectangle1 ? sourceRectangle2 : sourceRectangle1;
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0,0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            spriteBatch.End();
        }
    }

    public class UpMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(68, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(85, 10, 16, 17);

        public UpMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            currentFrame = currentFrame == sourceRectangle1 ? sourceRectangle2 : sourceRectangle1;
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }

    public class DownMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(0, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(17, 10, 16, 17);

        public DownMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            currentFrame = currentFrame == sourceRectangle1 ? sourceRectangle2 : sourceRectangle1;
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }

    public class RightIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);

        public RightIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update()
        {

        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }

    public class LeftIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);

        public LeftIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update()
        {

        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            spriteBatch.End();
        }
    }

    public class UpIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(68, 10, 16, 17);

        public UpIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }

    public class DownIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(0, 10, 16, 17);

        public DownIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
        }

        public void SpriteDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }
}



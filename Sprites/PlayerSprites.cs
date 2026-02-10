using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Sprites
{
    // Need a big class to manage textures and creations
    public class PlayerSpriteFactory
    {
        private Texture2D playerTexture;
        private SpriteBatch spriteBatch;
        public PlayerSpriteFactory(Texture2D playerTexture, SpriteBatch spriteBatch)
        {
            this.playerTexture = playerTexture;
            this.spriteBatch = spriteBatch;
        }

        public ISprite CreateRightMovingPlayerSprite(Vector2 position)
        {
            return new RightMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateLeftMovingPlayerSprite(Vector2 position)
        {
            return new LeftMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateUpMovingPlayerSprite(Vector2 position)
        {
            return new UpMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateDownMovingPlayerSprite(Vector2 position)
        {
            return new DownMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateRightIdlePlayerSprite(Vector2 position)
        {
            return new RightIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateLeftIdlePlayerSprite(Vector2 position)
        {
            return new LeftIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateUpIdlePlayerSprite(Vector2 position)
        {
            return new UpIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public ISprite CreateDownIdlePlayerSprite(Vector2 position)
        {
            return new DownIdlePlayerSprite(playerTexture, position, spriteBatch);
        }

    }


    public class RightMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(51, 10, 16, 17);
        private int frameCounter = 0;

        public RightMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            frameCounter++;
            if(frameCounter >= 10)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }

        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class LeftMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(51, 10, 16, 17);
        private int frameCounter = 0;

        public LeftMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            frameCounter++;
            if (frameCounter >= 10)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
        }
    }

    public class UpMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(68, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(85, 10, 16, 17);
        private int frameCounter = 0;

        public UpMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            frameCounter++;
            if (frameCounter >= 10)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class DownMovingPlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(0, 10, 16, 17);
        private Rectangle sourceRectangle2 = new Rectangle(17, 10, 16, 17);
        private int frameCounter = 0;

        public DownMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
            frameCounter++;
            if (frameCounter >= 10)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class RightIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);

        public RightIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update()
        {

        }

        public void SpriteDraw(Vector2 position)
        { 
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class LeftIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(34, 10, 16, 17);

        public LeftIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update()
        {

        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
        }
    }

    public class UpIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(68, 10, 16, 17);

        public UpIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class DownIdlePlayerSprite : ISprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        private Rectangle sourceRectangle1 = new Rectangle(0, 10, 16, 17);

        public DownIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update()
        {
        }

        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
            spriteBatch.End();
        }
    }
}



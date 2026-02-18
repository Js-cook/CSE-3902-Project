using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;

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

        public IPlayerSprite CreateRightMovingPlayerSprite(Vector2 position)
        {
            return new RightMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateLeftMovingPlayerSprite(Vector2 position)
        {
            return new LeftMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateUpMovingPlayerSprite(Vector2 position)
        {
            return new UpMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateDownMovingPlayerSprite(Vector2 position)
        {
            return new DownMovingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateRightIdlePlayerSprite(Vector2 position)
        {
            return new RightIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateLeftIdlePlayerSprite(Vector2 position)
        {
            return new LeftIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateUpIdlePlayerSprite(Vector2 position)
        {
            return new UpIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateDownIdlePlayerSprite(Vector2 position)
        {
            return new DownIdlePlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateLeftAttackingPlayerSprite(Vector2 position)
        {
            return new LeftAttackingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateRightAttackingPlayerSprite(Vector2 position)
        {
            return new RightAttackingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateUpAttackingPlayerSprite(Vector2 position)
        {
            return new UpAttackingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateDownAttackingPlayerSprite(Vector2 position)
        {
            return new DownAttackingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateLeftUsingPlayerSprite(Vector2 position)
        {
            return new LeftUsingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateRightUsingPlayerSprite(Vector2 position)
        {
            return new RightUsingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateUpUsingPlayerSprite(Vector2 position)
        {
            return new UpUsingPlayerSprite(playerTexture, position, spriteBatch);
        }
        public IPlayerSprite CreateDownUsingPlayerSprite(Vector2 position)
        {
            return new DownUsingPlayerSprite(playerTexture, position, spriteBatch);
        }
    }


    public class RightMovingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private string Direction { get; }

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(52, 11, 16, 16);
        private int frameCounter = 0;

        public RightMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
            Direction = "right";
        }

        public void Update(GameTime gametime)
        {
            frameCounter++;
            if (frameCounter >= 5)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }

        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            } else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class LeftMovingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(52, 11, 16, 16);
        private int frameCounter = 0;

        public LeftMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
            frameCounter++;
            if (frameCounter >= 5)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
    }

    public class UpMovingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(69, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(86, 11, 16, 16);
        private int frameCounter = 0;

        public UpMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
            frameCounter++;
            if (frameCounter >= 5)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            } else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class DownMovingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(1, 11, 16, 16);
        private Rectangle sourceRectangle2 = new Rectangle(18, 11, 16, 16);
        private int frameCounter = 0;

        public DownMovingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
            frameCounter++;
            if (frameCounter >= 5)
            {
                currentFrame = currentFrame.Equals(sourceRectangle1) ? sourceRectangle2 : sourceRectangle1;
                frameCounter = 0;
            }
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class RightIdlePlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }
        private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);

        public RightIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update(GameTime gametime)
        {

        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class LeftIdlePlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(35, 11, 16, 16);

        public LeftIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }
        public void Update(GameTime gametime)
        {

        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
    }

    public class UpIdlePlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(69, 11, 16, 16);

        public UpIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class DownIdlePlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        //private Vector2 position;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(1, 11, 16, 16);

        public DownIdlePlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            //this.position = position;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
        }

        public void Update(GameTime gametime)
        {
        }

        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class LeftAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private double attackTimer = 0.0;
        private double attackDuration = 0.4;

        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 77, 14, 15),
            new Rectangle(70, 77, 18, 15),
            new Rectangle(46, 77, 22, 15),
            new Rectangle(18, 77, 26, 15)
        };

        private int frameCounter = 0;

        public LeftAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }

        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.1)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.2 && attackTimer < 0.3)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.3 && attackTimer < 0.4)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.4)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }

    }

    public class RightAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private double attackTimer = 0.0;
        private double attackDuration = 0.4;
        public bool Hurt { get; set; }
        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 77, 14, 15),
            new Rectangle(70, 77, 18, 15),
            new Rectangle(46, 77, 22, 15),
            new Rectangle(18, 77, 26, 15)
        };
        public RightAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.1)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.2 && attackTimer < 0.3)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.3 && attackTimer < 0.4)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.4)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }
            

    public class UpAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        public bool Hurt { get; set; }

        private double attackTimer = 0.0;
        private double attackDuration = 0.4;

        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 109, 15, 15),
            new Rectangle(52, 106, 15, 18),
            new Rectangle(35, 98, 15, 26),
            new Rectangle(18, 97, 15, 27)
        };

        public UpAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.1)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.2 && attackTimer < 0.3)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.3 && attackTimer < 0.4)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.4)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
            spriteBatch.Draw(texture, position, currentFrame, Color.White);
        }
    }

    public class DownAttackingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;
        private double attackTimer = 0.0;
        private double attackDuration = 0.4;
        public bool Hurt { get; set; }
        private Rectangle[] frameContainer =
        {
            new Rectangle(1, 47, 15, 15),
            new Rectangle(52, 47, 15, 18),
            new Rectangle(35, 47, 15, 22),
            new Rectangle(18, 47, 15, 26)
        };
        public DownAttackingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = frameContainer[0];
        }
        public void Update(GameTime gametime)
        {
            attackTimer += gametime.ElapsedGameTime.TotalSeconds;
            if (attackTimer < 0.1)
            {
                currentFrame = frameContainer[0];
            }
            else if (attackTimer >= 0.1 && attackTimer < 0.2)
            {
                currentFrame = frameContainer[1];
            }
            else if (attackTimer >= 0.2 && attackTimer < 0.3)
            {
                currentFrame = frameContainer[2];
            }
            else if (attackTimer >= 0.3 && attackTimer < 0.4)
            {
                currentFrame = frameContainer[3];
            }
            else if (attackTimer >= 0.4)
            {
                currentFrame = frameContainer[0];
                attackTimer = 0.0;
            }
        }
        public void SpriteDraw(Vector2 position)
        {
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
    }

    public class LeftUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        public bool Hurt { get; set; }
        private Rectangle currentFrame = new Rectangle(124, 11, 15, 15);

        public LeftUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.FlipHorizontally, 0.0f);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

    public class RightUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame = new Rectangle(124, 11, 15, 15);

        public bool Hurt { get; set; }

        public RightUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

    public class UpUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        public bool Hurt { get; set; }
        private Rectangle currentFrame = new Rectangle(141, 11, 15, 15);

        public UpUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }

    public class DownUsingPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        public bool Hurt { get; set; }
        private Rectangle currentFrame = new Rectangle(107, 11, 15, 15);

        public DownUsingPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }

        public void SpriteDraw(Vector2 position)
        {
            //throw new NotImplementedException();
            if (Hurt)
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, position, currentFrame, Color.White);
            }
        }
        public void Update(GameTime gameTime)
        {
        }
    }
}
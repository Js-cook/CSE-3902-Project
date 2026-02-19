using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprites
{
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
}
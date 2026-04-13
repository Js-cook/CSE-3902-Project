using Enums;
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprites
{
    public class StunnedPlayerSprite : Interfaces.IPlayerSprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Rectangle currentFrame;

        public bool Hurt { get; set; }

        private Rectangle sourceRectangle1 = new Rectangle(69, 11, 16, 16);
        private float flickerTimer = 0f;
        private float flickerInterval = 0.05f; // How fast he flashes
        private int colorIndex = 0;
        private Color[] flashColors = { Color.White, Color.Red, Color.Blue, Color.Yellow };
        private Color currColor;

        private IPlayerSprite decoratedSprite;


        private int scale = 3;

        public int Height => currentFrame.Height * scale;
        public int Width => currentFrame.Width * scale;


        public StunnedPlayerSprite(Texture2D texture, Vector2 position, SpriteBatch spriteBatch, IPlayerSprite decoratedSprite)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            currentFrame = sourceRectangle1;
            currColor = flashColors[colorIndex];

            this.decoratedSprite = decoratedSprite;
        }



        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            flickerTimer += elapsed;

            // Logic for flashing colors
            if (flickerTimer >= flickerInterval)
            {
                flickerTimer = 0;
                colorIndex = (colorIndex + 1) % flashColors.Length;

                // Apply the color to the player's sprite
                // Note: This requires your IPlayerSprite to have a Color or Tint property
                 currColor = flashColors[colorIndex];
            }

     
        }


        public void SpriteDraw(Vector2 position, Color color)
        {
            
            
               this.decoratedSprite.SpriteDraw(position, currColor);
            
        }
    }

}

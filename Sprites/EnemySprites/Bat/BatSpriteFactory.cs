using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BatSpriteFactory
{
    private Texture2D batTexture;
    private SpriteBatch spriteBatch;
    public BatSpriteFactory(Texture2D batTexture, SpriteBatch spriteBatch)
    {
        this.batTexture = batTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateBatMovingSprite(Vector2 position)
    {
        return new MovingBatSprite(batTexture, position, spriteBatch);
    }

}


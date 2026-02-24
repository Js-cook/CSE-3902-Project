using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class WallmasterSpriteFactory
{
    private Texture2D wallmasterTexture;
    private SpriteBatch spriteBatch;
    public WallmasterSpriteFactory(Texture2D wallmasterTexture, SpriteBatch spriteBatch)
    {
        this.wallmasterTexture = wallmasterTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingWallmasterSprite(Vector2 position)
    {
        return new MovingWallmasterSprite(wallmasterTexture, position, spriteBatch);
    }

}









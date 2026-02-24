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



public class SkeletonSpriteFactory
{
    private Texture2D skeletonTexture;
    private SpriteBatch spriteBatch;
    public SkeletonSpriteFactory(Texture2D skeletonTexture, SpriteBatch spriteBatch)
    {
        this.skeletonTexture = skeletonTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingSkeletonSprite(Vector2 position)
    {
        return new MovingSkeletonSprite(skeletonTexture, position, spriteBatch);
    }

}










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



public class GelSpriteFactory
{
    private Texture2D gelTexture;
    private SpriteBatch spriteBatch;
    public GelSpriteFactory(Texture2D gelTexture, SpriteBatch spriteBatch)
    {
        this.gelTexture = gelTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingGelSprite(Vector2 position)
    {
        return new MovingGelSprite(gelTexture, position, spriteBatch);
    }

}









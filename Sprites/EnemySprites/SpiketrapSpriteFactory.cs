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



public class SpiketrapSpriteFactory
{
    private Texture2D spiketrapTexture;
    private SpriteBatch spriteBatch;
    public SpiketrapSpriteFactory(Texture2D spiketrapTexture, SpriteBatch spriteBatch)
    {
        this.spiketrapTexture = spiketrapTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingSpiketrapSprite(Vector2 position)
    {
        return new MovingSpiketrapSprite(spiketrapTexture, position, (SpriteBatch)this.spriteBatch);
    }

}









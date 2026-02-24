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



public class AquamentusSpriteFactory
{
    private Texture2D aquamentusTexture;
    private SpriteBatch spriteBatch;
    public AquamentusSpriteFactory(Texture2D aquamentusTexture, SpriteBatch spriteBatch)
    {
        this.aquamentusTexture = aquamentusTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateMovingAquamentusSprite(Vector2 position)
    {
        return new MovingAquamentusSprite(aquamentusTexture, position, spriteBatch);
    }

    

}












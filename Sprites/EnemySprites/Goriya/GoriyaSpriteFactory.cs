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



public class GoriyaSpriteFactory
{
    private Texture2D goriyaTexture;
    private SpriteBatch spriteBatch;
    public GoriyaSpriteFactory(Texture2D goriyaTexture, SpriteBatch spriteBatch)
    {
        this.goriyaTexture = goriyaTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateLeftMovingGoriyaSprite(Vector2 position)
    {
        return new LeftMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateRightMovingGoriyaSprite(Vector2 position)
    {
        return new RightMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateUpMovingGoriyaSprite(Vector2 position)
    {
        return new UpMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateDownMovingGoriyaSprite(Vector2 position)
    {
        return new DownMovingGoriyaSprite(goriyaTexture, position, spriteBatch);
    }

    public ISprite CreateDamagedGoriyaSprite(Vector2 position, Enums.Direction currDirection)
    {
       switch (currDirection)
        {
            case Enums.Direction.UP:
                return new UpDamagedGoriyaSprite(goriyaTexture, position, spriteBatch, currDirection);
            case Enums.Direction.DOWN:
                return new DownDamagedGoriyaSprite(goriyaTexture, position, spriteBatch, currDirection);
            case Enums.Direction.LEFT:
                return new LeftDamagedGoriyaSprite(goriyaTexture, position, spriteBatch, currDirection);
            case Enums.Direction.RIGHT:
                return new RightDamagedGoriyaSprite(goriyaTexture, position, spriteBatch, currDirection);
            default:
                return null;
        }
    }

}





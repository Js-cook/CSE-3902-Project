using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class TileFactory
{
    private Texture2D tileTexture;
    private SpriteBatch spriteBatch;

    public TileFactory(Texture2D tileTexture, SpriteBatch spriteBatch)
    {
        this.tileTexture = tileTexture;
        this.spriteBatch = spriteBatch;
    }

    public ISprite CreateStatueSprite()
    {
        return new StatueSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateSquareBlockSprite()
    {
        return new SquareBlockSprite(tileTexture, spriteBatch);
    }
    public ISprite CreateBlueGapSprite()
    {
        return new BlueGapSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateStairSprite()
    {
        return new StairSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateWhiteBrickSprite()
    {
        return new WhiteBrickSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateLadderSprite()
    {
        return new LadderSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBlueFloorSprite()
    {
        return new BlueFloorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBlueSandSprite()
    {
        return new BlueSandSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateWallSprite()
    {
        return new WallSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateBombedWallSprite()
    {
        return new BombedWallSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateOpenDoorSprite()
    {
        return new OpenDoorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateKeyLockedDoorSprite()
    {
        return new KeyLockedDoorSprite(tileTexture, spriteBatch);
    }

    public ISprite CreateDiamondLockedDoorSprite()
    {
        return new DiamondLockedDoorSprite(tileTexture, spriteBatch);
    }
}

public class StatueSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(339, 74, 16, 16);

    public StatueSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class SquareBlockSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(323, 90, 16, 16);

    public SquareBlockSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class BlueGapSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(1018, 28, 16, 16);

    public BlueGapSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class StairSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(323, 59, 16, 16);

    public StairSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class WhiteBrickSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(984, 45, 16, 16);

    public WhiteBrickSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class LadderSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(1001, 45, 16, 16);

    public LadderSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class BlueFloorSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(339, 59, 16, 16);

    public BlueFloorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class BlueSandSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(1001, 28, 16, 16);

    public BlueSandSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class WallSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(815, 11, 32, 32);

    public WallSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class BombedWallSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(947, 11, 32, 32);

    public BombedWallSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class OpenDoorSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(848, 11, 32, 32);

    public OpenDoorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class KeyLockedDoorSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(881, 11, 32, 32);

    public KeyLockedDoorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}

public class DiamondLockedDoorSprite : BaseTile
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;

    private Rectangle sourceRectangle = new Rectangle(914, 11, 32, 32);

    public DiamondLockedDoorSprite(Texture2D texture, SpriteBatch spriteBatch)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void SpriteDraw(Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InventoryMapTileSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private Vector2 source;

    public InventoryMapTileSprite(SpriteBatch spriteBatch, Texture2D texture, Vector2 source)
    {
        this.spriteBatch = spriteBatch;
        this.texture = texture;
        this.source = source;
    }

    public void SpriteDraw(Vector2 position)
    {
        spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 8*4, 8*4), new Rectangle((int)source.X, (int)source.Y, 8, 8), Color.White);
    }

    public void Update(GameTime gameTime)
    {

    }
}
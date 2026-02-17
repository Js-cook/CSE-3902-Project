using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class WallTile
{
    private ISprite blockSprite;
    public Vector2 Position { get; set; }

    public WallTile(ISprite sprite, Vector2 location)
    {
        blockSprite = sprite;
        Position = location;
    }

    public void Update()
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        blockSprite.SpriteDraw(Position);
    }
}

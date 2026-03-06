using Microsoft.Xna.Framework;

public class Tile : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSolid { get; set; }
    public bool HitboxActive { get; set; } = true; // Tiles are always active

    

    public Rectangle Hitbox
    {
        get 
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32 , 32);
        }
    }

    public Tile(ISprite sprite, Vector2 position, bool isSolid)
    {
        Sprite = sprite;
        Position = position;
        IsSolid = isSolid;
    }
}

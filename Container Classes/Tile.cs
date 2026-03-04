using Microsoft.Xna.Framework;

public class Tile : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSolid { get; set; }
    
    public Rectangle Hitbox
    {
        get 
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
        }
    }
    public bool HitboxActive { get; set; }

    public Tile(ISprite sprite, Vector2 position, bool isSolid)
    {
        Sprite = sprite;
        Position = position;
        IsSolid = isSolid;
    }
}

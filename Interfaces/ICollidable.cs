using Microsoft.Xna.Framework;

public interface ICollidable
{
    public Rectangle Hitbox { get; }
    public bool HitboxActive { get; set; }
}
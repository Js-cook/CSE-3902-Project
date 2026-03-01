using Microsoft.Xna.Framework;

public interface ICollisionHandler {

    void HandleCollision(ICollidable obj1,  ICollidable obj2, Rectangle intersection);
}

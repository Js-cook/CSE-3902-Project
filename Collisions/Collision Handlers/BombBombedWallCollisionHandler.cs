using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

public class BombBombedWallCollisionHandler : ICollisionHandler
{
    private RoomManager roomManager;
    private TileFactory tileFactory;
    private Dictionary<string, SoundEffect> sfx;

    public BombBombedWallCollisionHandler(RoomManager roomManager, TileFactory tileFactory, Dictionary<string, SoundEffect> sfx = null)
    {
        this.roomManager = roomManager;
        this.tileFactory = tileFactory;
        this.sfx = sfx;
    }

    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Bomb bomb = obj1 as Bomb ?? obj2 as Bomb;
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;

        if (bomb == null || doorway == null)
            return;

        // Only handle bombed walls that are still closed
        if (!doorway.IsBombedWall || !doorway.IsLocked)
            return;

        // Only trigger when bomb is in its damage window (exploding)
        if (!bomb.HitboxActive)
            return;

        // Bomb opens the bombed wall
        doorway.IsLocked = false;
        doorway.IsBombedWall = false;

        // First show the bombed/cracked wall sprite briefly for visual effect
        doorway.Sprite = tileFactory.CreateBombedWallSprite(doorway.Direction);

        // Then immediately change to open door (or add a timer for delayed opening if desired)
        doorway.Sprite = tileFactory.CreateOpenDoorSprite(doorway.Direction);

        // Track the unlocked door globally so it stays open
        roomManager.UnlockDoor(doorway.Direction);

        // Play bomb/explosion sound (already plays from bomb damage, so we could add a specific wall break sound here)
        if (sfx != null && sfx.ContainsKey("BombDrop")) // Using BombDrop as placeholder for wall break sound
        {
            sfx["BombDrop"].Play(0.5f, 0.0f, 0.0f);
        }
    }
}

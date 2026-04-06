using Microsoft.Xna.Framework;

public class PlayerDoorwayCollisionHandler : ICollisionHandler
{
    private RoomManager roomManager;
    private TileFactory tileFactory;
    private bool transitioning;

    public PlayerDoorwayCollisionHandler(RoomManager roomManager, TileFactory tileFactory)
    {
        this.roomManager = roomManager;
        this.tileFactory = tileFactory;
        this.transitioning = false;
    }

    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;

        if (player == null || doorway == null)
            return;

        if (!doorway.HitboxActive)
            return;

        // Handles Locked Doors - checks if the door is locked and if the player has a key to unlock it
        if (doorway.IsLocked)
        {
            if (player.playerInventory.keys > 0)
            {
                // Player has a key - unlock the door
                doorway.IsLocked = false;
                player.playerInventory.keys--;

                // Change sprite to open door
                doorway.Sprite = tileFactory.CreateOpenDoorSprite(doorway.Direction);

                // Track the unlocked door globally so it stays unlocked
                roomManager.UnlockDoor(doorway.Direction);

                // TODO: Add audio for unlocking the door

                // Return to allow the door state to update; player will transition on next collision
                return;
            }
            else
            {
                // Player doesn't have a key - block them like a wall
                // Push player back based on door direction
                switch (doorway.Direction)
                {
                    case 0: // Top door - push player down
                        player.position = new Vector2(player.position.X, player.position.Y + intersection.Height);
                        break;
                    case 1: // Right door - push player left
                        player.position = new Vector2(player.position.X - intersection.Width, player.position.Y);
                        break;
                    case 2: // Bottom door - push player up
                        player.position = new Vector2(player.position.X, player.position.Y - intersection.Height);
                        break;
                    case 3: // Left door - push player right
                        player.position = new Vector2(player.position.X + intersection.Width, player.position.Y);
                        break;
                }

                // TODO: Play locked sound & show message
                return;
            }
        }

        if (transitioning)
            return;

        transitioning = true;

        switch (doorway.Direction)
        {
            case 0:
                roomManager.MoveUp();
                player.position = new Vector2(player.position.X, 700);
                break;
            case 1:
                roomManager.MoveRight();
                player.position = new Vector2(180, player.position.Y);
                break;
            case 2:
                roomManager.MoveDown();
                player.position = new Vector2(player.position.X, 320);
                break;
            case 3:
                roomManager.MoveLeft();
                player.position = new Vector2(820, player.position.Y);
                break;
        }

        transitioning = false;
    }
}
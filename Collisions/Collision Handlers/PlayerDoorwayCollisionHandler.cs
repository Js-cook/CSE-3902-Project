using Microsoft.Xna.Framework;

public class PlayerDoorwayCollisionHandler : ICollisionHandler
{
    private RoomManager roomManager;
    private bool transitioning;

    public PlayerDoorwayCollisionHandler(RoomManager roomManager)
    {
        this.roomManager = roomManager;
        this.transitioning = false;
    }

    public void HandleCollision(ICollidable obj1, ICollidable obj2, Rectangle intersection)
    {
        Link player = obj1 as Link ?? obj2 as Link;
        Doorway doorway = obj1 as Doorway ?? obj2 as Doorway;

        if (player == null || doorway == null)
            return;

        if (!doorway.HitboxActive || doorway.IsLocked)
            return;

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
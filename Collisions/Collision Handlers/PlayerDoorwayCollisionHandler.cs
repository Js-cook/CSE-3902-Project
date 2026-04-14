using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Diagnostics;
using Enums;

public class PlayerDoorwayCollisionHandler : ICollisionHandler
{
    private RoomManager roomManager;
    private TileFactory tileFactory;
    private bool transitioning;
    private Dictionary<string, SoundEffect> sfx;

    public PlayerDoorwayCollisionHandler(RoomManager roomManager, TileFactory tileFactory, Dictionary<string, SoundEffect> sfx = null)
    {
        this.roomManager = roomManager;
        this.tileFactory = tileFactory;
        this.transitioning = false;
        this.sfx = sfx;
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
            // Handle bombed walls separately - they need bombs, not keys
            if (doorway.IsBombedWall)
            {
                // Player can't unlock bombed walls with keys - push them back
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

                // Show message that they need a bomb
                player.ShowMessage("Use a bomb to open this!");

                return;
            }

            // Handle diamond locked doors - they can't be opened by player, only by triggers
            if (doorway.TriggerType != DoorTriggerType.None)
            {
                // Push player back - diamond doors can't be manually opened
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

                // Show message based on trigger type
                string message = doorway.TriggerType switch
                {
                    DoorTriggerType.AllEnemies => "DIAMOND DOOR: Defeat all enemies!",
                    DoorTriggerType.BlockPushed => "DIAMOND DOOR: Push the block!",
                    DoorTriggerType.Boss => "DIAMOND DOOR: Defeat the boss!",
                    _ => "This door is locked!"
                };
                player.ShowMessage(message);

                return;
            }

            // Regular key-locked doors
            if (player.playerInventory.keys > 0)
            {
                // Player has a key - unlock the door
                doorway.IsLocked = false;
                player.playerInventory.keys--;

                // Change sprite to open door
                doorway.Sprite = tileFactory.CreateOpenDoorSprite(doorway.Direction);

                // Track the unlocked door globally so it stays unlocked
                roomManager.UnlockDoor(doorway.Direction);

                // Play unlock sound
                if (sfx != null && sfx.ContainsKey("DoorUnlock"))
                {
                    sfx["DoorUnlock"].Play();
                }

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

                // Play locked door sound
                if (sfx != null && sfx.ContainsKey("DoorLocked"))
                {
                    sfx["DoorLocked"].Play(0.3f, 0.0f, 0.0f); // Lower volume
                }

                // Show message (player needs to handle this)
                player.ShowMessage("You need a key!");

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

        player.playerInventory.currentRoom = new Vector2(roomManager.CurrentRow, roomManager.CurrentCol);
        transitioning = false;
    }
}
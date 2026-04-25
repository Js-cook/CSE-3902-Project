using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Enums;

public class PlayerDoorwayCollisionHandler : ICollisionHandler
{
    private RoomManager roomManager;
    private TileFactory tileFactory;
    private DateTime nextAllowedTransitionTime;
    private static readonly TimeSpan TransitionCooldown = TimeSpan.FromMilliseconds(400);
    private Dictionary<string, SoundEffect> sfx;
    private Action<int> onTransition;

    public PlayerDoorwayCollisionHandler(RoomManager roomManager, TileFactory tileFactory, Dictionary<string, SoundEffect> sfx = null, Action<int> onTransition = null)
    {
        this.roomManager = roomManager;
        this.tileFactory = tileFactory;
        this.nextAllowedTransitionTime = DateTime.MinValue;
        this.sfx = sfx;
        this.onTransition = onTransition;
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
            System.Diagnostics.Debug.WriteLine($"*** COLLISION: Player hit locked door at direction {doorway.Direction}, TriggerType={doorway.TriggerType}, HashCode={doorway.GetHashCode()}");

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
                    DoorTriggerType.TriForcePieceAcquired => "DIAMOND DOOR: Acquire the triforce piece",
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

        if (DateTime.UtcNow < nextAllowedTransitionTime)
            return;

        if (onTransition != null)
        {
            onTransition(doorway.Direction);
            return;
        }

        nextAllowedTransitionTime = DateTime.UtcNow + TransitionCooldown;

        int spawnInset = 64;
        int centerOffset = 32;
        Vector2 spawnPos = player.position;

        // Move room + get correct doorway
        if (doorway.Direction == 0)
        {
            roomManager.MoveUp();
            spawnPos = roomManager.GetCurrentEnvironment().GetDoorPosition(2);
        }
        if (doorway.Direction == 1)
        {
            roomManager.MoveRight();
            spawnPos = roomManager.GetCurrentEnvironment().GetDoorPosition(3);
        }
        if (doorway.Direction == 2)
        {
            roomManager.MoveDown();
            spawnPos = roomManager.GetCurrentEnvironment().GetDoorPosition(0);
        }
        if (doorway.Direction == 3)
        {
            roomManager.MoveLeft();
            spawnPos = roomManager.GetCurrentEnvironment().GetDoorPosition(1);
        }

        // Move Link slightly INSIDE doorway
        if (doorway.Direction == 0)
        {
            spawnPos.X += centerOffset;
            spawnPos.Y -= spawnInset;
        }
        if (doorway.Direction == 1)
        {
            spawnPos.X += spawnInset;
            spawnPos.Y += centerOffset;
        }
        if (doorway.Direction == 2)
        {
            spawnPos.X += centerOffset;
            spawnPos.Y += spawnInset;
        }
        if (doorway.Direction == 3)
        {
            spawnPos.X -= spawnInset;
            spawnPos.Y += centerOffset;
        }

        player.position = spawnPos;

        player.playerInventory.currentRoom = new Vector2(roomManager.CurrentRow, roomManager.CurrentCol);

    }
}
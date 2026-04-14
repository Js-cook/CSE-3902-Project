using Enums;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Manages opening DiamondLockedDoors based on different trigger conditions.
/// 
/// HOW TO USE DIAMOND DOORS IN ROOM DEFINITIONS:
/// =============================================
/// 
/// Diamond doors can be opened by different triggers. Use this syntax in your room definition:
/// 
/// 1. OPENS WHEN ALL ENEMIES ARE KILLED:
///    { "Top", "DiamondLockedDoor:AllEnemies" }
/// 
/// 2. OPENS WHEN A PUSHABLE BLOCK IS PUSHED:
///    { "Right", "DiamondLockedDoor:BlockPushed" }
/// 
/// 3. OPENS WHEN BOSS (AQUAMENTUS) IS KILLED:
///    { "Bottom", "DiamondLockedDoor:Boss" }
/// 
/// EXAMPLE ROOM DEFINITION:
/// ------------------------
/// var doors = new Dictionary&lt;string, string&gt; 
/// { 
///     { "Top", "DiamondLockedDoor:AllEnemies" },   // Opens when all enemies killed
///     { "Right", "DiamondLockedDoor:BlockPushed" }, // Opens when block pushed
///     { "Bottom", "DiamondLockedDoor:Boss" },      // Opens when Aquamentus dies
///     { "Left", "OpenDoor" }                        // Normal open door
/// };
/// 
/// NOTE: Door stays unlocked after trigger condition is met (persists across room transitions)
/// </summary>
public class DiamondDoorManager
{
    private Environment environment;
    private TileFactory tileFactory;
    private RoomManager roomManager;

    public DiamondDoorManager(Environment environment, TileFactory tileFactory, RoomManager roomManager)
    {
        this.environment = environment;
        this.tileFactory = tileFactory;
        this.roomManager = roomManager;
    }

    public void OnAllEnemiesKilled()
    {
        OpenDiamondDoorsByTrigger(DoorTriggerType.AllEnemies);
    }

    public void OnBossDeath()
    {
        OpenDiamondDoorsByTrigger(DoorTriggerType.Boss);
    }

    public void OnBlockPushed()
    {
        OpenDiamondDoorsByTrigger(DoorTriggerType.BlockPushed);
    }

    private void OpenDiamondDoorsByTrigger(DoorTriggerType triggerType)
    {
        // Find all diamond doors with matching trigger type
        var doorsToOpen = environment.doorways
            .Where(d => d.IsLocked && d.TriggerType == triggerType)
            .ToList();

        foreach (var door in doorsToOpen)
        {
            OpenDiamondDoor(door);
        }
    }

    private void OpenDiamondDoor(Doorway door)
    {
        // Unlock the door
        door.IsLocked = false;

        // Change sprite to open door
        door.Sprite = tileFactory.CreateOpenDoorSprite(door.Direction);

        // Track globally so it stays open
        roomManager.UnlockDoor(door.Direction);
    }
}

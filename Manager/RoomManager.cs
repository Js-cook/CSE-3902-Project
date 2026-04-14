using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Microsoft.Xna.Framework;

public class RoomManager
{
    private LevelFileReader reader;
    private EnemyController enemyController;
    private HashSet<(int row, int col)> clearedRooms = new HashSet<(int row, int col)>();
    private HashSet<(int row, int col, int direction)> unlockedDoors = new HashSet<(int row, int col, int direction)>();

    public int CurrentRow { get; private set; }
    public int CurrentCol { get; private set; }


    private readonly int startRow;
    private readonly int startCol;

    public RoomManager(LevelFileReader reader, int startRow, int startCol, EnemyController enemyController)
    {
        this.reader = reader;
        this.enemyController = enemyController;
        if (this.enemyController != null)
        {
            this.enemyController.AllEnemiesKilled += OnAllEnemiesKilled;
        }

        // Load initial room
        this.CurrentRow = startRow;
        this.CurrentCol = startCol;

        this.startRow = startRow;
        this.startCol = startCol;
        reader.LoadLevel(CurrentRow, CurrentCol, this, !IsRoomCleared(CurrentRow, CurrentCol));
    }

    public void MoveUp() { TryTransition(CurrentRow - 1, CurrentCol); }
    public void MoveDown() { TryTransition(CurrentRow + 1, CurrentCol); }
    public void MoveLeft() { TryTransition(CurrentRow, CurrentCol - 1); }
    public void MoveRight() { TryTransition(CurrentRow, CurrentCol + 1); }

    private void TryTransition(int nextRow, int nextCol)
    {
        // Only update row/col if the load actually succeeds
        if (reader.LoadLevel(nextRow, nextCol, this, !IsRoomCleared(nextRow, nextCol)))
        {
            CurrentRow = nextRow;
            CurrentCol = nextCol;
        }
    }

    private void OnAllEnemiesKilled()
    {
        clearedRooms.Add((CurrentRow, CurrentCol));
    }

    public bool IsRoomCleared(int row, int col)
    {
        return clearedRooms.Contains((row, col));
    }

    public void UnlockDoor(int direction)
    {
        // Unlock the door from the current room's perspective
        unlockedDoors.Add((CurrentRow, CurrentCol, direction));

        // Unlock the door from the adjacent room's perspective
        // Direction mapping: 0=Top, 1=Right, 2=Bottom, 3=Left
        // Opposite directions: 0<->2 (Top<->Bottom), 1<->3 (Right<->Left)
        int adjacentRow = CurrentRow;
        int adjacentCol = CurrentCol;
        int oppositeDirection = direction;

        switch (direction)
        {
            case 0: // Top door - adjacent room is above (row-1), opposite is Bottom (2)
                adjacentRow = CurrentRow - 1;
                oppositeDirection = 2;
                break;
            case 1: // Right door - adjacent room is to the right (col+1), opposite is Left (3)
                adjacentCol = CurrentCol + 1;
                oppositeDirection = 3;
                break;
            case 2: // Bottom door - adjacent room is below (row+1), opposite is Top (0)
                adjacentRow = CurrentRow + 1;
                oppositeDirection = 0;
                break;
            case 3: // Left door - adjacent room is to the left (col-1), opposite is Right (1)
                adjacentCol = CurrentCol - 1;
                oppositeDirection = 1;
                break;
        }

        // Unlock the opposite side of the door in the adjacent room
        unlockedDoors.Add((adjacentRow, adjacentCol, oppositeDirection));
    }

    public bool IsDoorUnlocked(int row, int col, int direction)
    {
        return unlockedDoors.Contains((row, col, direction));
    }


    public void ResetDungeon(Link player)
    {
        System.Diagnostics.Debug.WriteLine("--- RESET DUNGEON CALLED ---");
        System.Diagnostics.Debug.WriteLine($"Target: Row {startRow}, Col {startCol}");

        // 1. Check if the reader is successfully loading the level
        bool loadSuccess = reader.LoadLevel(startRow, startCol, this, !IsRoomCleared(startRow, startCol));
        System.Diagnostics.Debug.WriteLine($"Load Success: {loadSuccess}");

        if (loadSuccess)
        {
            CurrentRow = startRow;
            CurrentCol = startCol;
            System.Diagnostics.Debug.WriteLine("Room coordinates updated.");
        }

        // 2. Check Link's State
        player.playerState = new RightIdlePlayerState(player, player.playerSpriteFactory, player.projectileController, player.soundEffect);
        player.HitboxActive = true;
        player.position = new Vector2(400 * 2, 250 * 2);
        System.Diagnostics.Debug.WriteLine($"Player teleported to: {player.position.X}, {player.position.Y}");
    }
}

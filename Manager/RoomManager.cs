using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

public class RoomManager
{
    private LevelFileReader reader;
    private EnemyController enemyController;
    private HashSet<(int row, int col)> clearedRooms = new HashSet<(int row, int col)>();

    public int CurrentRow { get; private set; }
    public int CurrentCol { get; private set; }

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
        reader.LoadLevel(CurrentRow, CurrentCol, !IsRoomCleared(CurrentRow, CurrentCol));
    }

    public void MoveUp() { TryTransition(CurrentRow - 1, CurrentCol); }
    public void MoveDown() { TryTransition(CurrentRow + 1, CurrentCol); }
    public void MoveLeft() { TryTransition(CurrentRow, CurrentCol - 1); }
    public void MoveRight() { TryTransition(CurrentRow, CurrentCol + 1); }

    private void TryTransition(int nextRow, int nextCol)
    {
        // Only update row/col if the load actually succeeds
        if (reader.LoadLevel(nextRow, nextCol, !IsRoomCleared(nextRow, nextCol)))
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
}
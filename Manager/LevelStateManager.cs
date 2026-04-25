using Enums;
using System;
using System.Diagnostics;

public class LevelStateManager
{
    private DungeonLevel currentLevel;

    public DungeonLevel CurrentLevel
    {
        get => currentLevel;
        set
        {
            if (currentLevel != value)
            {
                Debug.WriteLine($"[LevelStateManager] Switching dungeon level from {currentLevel} to {value}");
                currentLevel = value;
                RoomsRepository.SetActiveLevel(value);
            }
        }
    }

    public LevelStateManager(DungeonLevel initialLevel = DungeonLevel.Level1)
    {
        currentLevel = initialLevel;
        RoomsRepository.SetActiveLevel(initialLevel);
    }



}
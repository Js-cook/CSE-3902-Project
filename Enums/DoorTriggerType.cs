namespace Enums
{
    public enum DoorTriggerType
    {
        None,           // Normal doors (key/bomb/open)
        AllEnemies,     // Opens when all enemies in room are killed
        BlockPushed,    // Opens when a pushable block is moved
        Boss,            // Opens when boss (Aquamentus) is killed
        TriForcePieceAcquired // Opens when triforce piece is acquired
    }
}

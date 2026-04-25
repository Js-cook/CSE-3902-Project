using System.Collections.Generic;

public class DoorCalculator
{
    public void AssignDoors(List<RoomNode> rooms, HashSet<(int row, int col)> occupied)
    {
        foreach (var room in rooms)
        {
            if (occupied.Contains((room.Row - 1, room.Col))) room.TopDoor = "OpenDoor";
            if (occupied.Contains((room.Row + 1, room.Col))) room.BottomDoor = "OpenDoor";
            if (occupied.Contains((room.Row, room.Col - 1))) room.LeftDoor = "OpenDoor";
            if (occupied.Contains((room.Row, room.Col + 1))) room.RightDoor = "OpenDoor";

            // Add a door to the left of room (1, 0) --> Starting room for level 2
            if (room.Row == 1 && room.Col == 0)
            {
                room.LeftDoor = "OpenDoor";
            }
        }
    }
}
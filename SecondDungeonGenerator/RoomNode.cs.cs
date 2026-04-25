using System.Xml.Linq;

public class RoomNode
{
    public int Row { get; set; }
    public int Col { get; set; }
    public XElement TilesData { get; set; } // XElements represent an XML element
    public string TopDoor { get; set; } = "Wall";
    public string BottomDoor { get; set; } = "Wall";
    public string LeftDoor { get; set; } = "Wall";
    public string RightDoor { get; set; } = "Wall";
    public XElement EnemiesData { get; set; } 

    public RoomNode(int row, int col)
    {
        Row = row;
        Col = col;
    }
}
using System.Collections.Generic;
using System.Xml.Linq;

public class DungeonXMLExporter
{
    public void Export(List<RoomNode> rooms, string outputPath)
    {
        XElement root = new XElement("Dungeon2");

        foreach (var room in rooms)
        {
            XElement roomXml = new XElement("Room",
                new XAttribute("row", room.Row),
                new XAttribute("col", room.Col),
                room.TilesData,
                new XElement("Doors",
                    new XElement("Top", new XAttribute("type", room.TopDoor)),
                    new XElement("Right", new XAttribute("type", room.RightDoor)),
                    new XElement("Bottom", new XAttribute("type", room.BottomDoor)),
                    new XElement("Left", new XAttribute("type", room.LeftDoor))
                )
                //TODO: Add new XElement for Enemies and Items
            );

            root.Add(roomXml);
        }

        XDocument doc = new XDocument(root);
        doc.Save(outputPath);
    }
}
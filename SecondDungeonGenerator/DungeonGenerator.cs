using System;
using System.Collections.Generic;

public class DungeonGenerator
{
    private readonly TemplateLoader _templateLoader;
    private readonly GraphGenerator _graphGenerator;
    private readonly RoomTemplateAssigner _templateAssigner;
    private readonly DoorCalculator _doorCalculator;
    private readonly DungeonXMLExporter _xmlExporter;
    private readonly Random _random;

    public DungeonGenerator()
    {
        // Initialize our isolated logic blocks
        _templateLoader = new TemplateLoader();
        _graphGenerator = new GraphGenerator(gridSize: 6);
        _templateAssigner = new RoomTemplateAssigner(maxTemplateUses: 3);
        _doorCalculator = new DoorCalculator();
        _xmlExporter = new DungeonXMLExporter();
        _random = new Random();
    }

    public void Generate(string sourceXmlPath, string outputXmlPath)
    {
        // Extract Templates
        var templates = _templateLoader.LoadTemplates(sourceXmlPath);

        // Determine Room Count and Generate Layout Map
        int targetRoomCount = _random.Next(5, 37);
        var occupiedCells = _graphGenerator.Generate(targetRoomCount, startNode: (1, 0));

        // Create Room Node Objects
        List<RoomNode> dungeonRooms = new List<RoomNode>();
        foreach (var cell in occupiedCells)
        {
            dungeonRooms.Add(new RoomNode(cell.row, cell.col));
        }

        // Run through the pipeline
        _templateAssigner.Assign(dungeonRooms, templates);
        _doorCalculator.AssignDoors(dungeonRooms, occupiedCells);

      

        // 5. Save the final result
        _xmlExporter.Export(dungeonRooms, outputXmlPath);
    }
}
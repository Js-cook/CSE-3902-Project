using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class RoomTemplateAssigner
{
    private readonly int _maxTemplateUses;
    private readonly Random _random;

    public RoomTemplateAssigner(int maxTemplateUses = 3)
    {
        _maxTemplateUses = maxTemplateUses;
        _random = new Random();
    }

    public void Assign(List<RoomNode> rooms, List<XElement> templates)
    {
        int[] templateUsage = new int[templates.Count];

        foreach (var room in rooms)
        {
            int templateIndex;
            do
            {
                templateIndex = _random.Next(0, templates.Count);
            } while (templateUsage[templateIndex] >= _maxTemplateUses);

            templateUsage[templateIndex]++;

            // Deep clone so multiple rooms don't share the same reference in memory
            room.TilesData = new XElement(templates[templateIndex]);
        }
    }
}
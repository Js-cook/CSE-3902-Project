using System;
using System.Collections.Generic;

public class GraphGenerator
{
    private readonly int _gridSize;
    private readonly Random _random;

    public GraphGenerator(int gridSize = 6)
    {
        _gridSize = gridSize;
        _random = new Random();
    }

    // This method implements a randomized Breadth-First Search algorithm to generate a 
    // randomized dungeon map. 
    public HashSet<(int row, int col)> Generate(int targetCount, (int row, int col) startNode)
    {
        HashSet<(int row, int col)> visited = new HashSet<(int row, int col)>();
        visited.Add(startNode);

        List<(int row, int col)> potentialNeighbors = new List<(int row, int col)>();
        AddValidNeighbors(startNode, visited, potentialNeighbors);

        while (visited.Count < targetCount && potentialNeighbors.Count > 0)
        {
            int index = _random.Next(0, potentialNeighbors.Count);
            var nextRoom = potentialNeighbors[index];

            visited.Add(nextRoom);
            potentialNeighbors.RemoveAt(index);

            AddValidNeighbors(nextRoom, visited, potentialNeighbors);
        }
        return visited;
    }

    private void AddValidNeighbors((int row, int col) cell, HashSet<(int row, int col)> visited, List<(int row, int col)> potentialNeighbors)
    {
        (int r, int c)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        foreach (var dir in directions)
        {
            int newRow = cell.row + dir.r;
            int newCol = cell.col + dir.c;

            if (newRow >= 0 && newRow < _gridSize && newCol >= 0 && newCol < _gridSize)
            {
                var neighbor = (newRow, newCol);
                if (!visited.Contains(neighbor) && !potentialNeighbors.Contains(neighbor))
                {
                    potentialNeighbors.Add(neighbor);
                }
            }
        }
    }
}
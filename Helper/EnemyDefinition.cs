using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnemyDefinition
{
    public string Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int count { get; set; } // used for wallmaster manager

    public EnemyDefinition(string type, int x, int y, int count = 1)
    {
        Type = type;
        X = x;
        Y = y;
        this.count = count;
    }
}
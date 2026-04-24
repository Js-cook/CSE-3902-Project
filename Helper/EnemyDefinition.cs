using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnemyDefinition
{
    public string Type { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public int count { get; set; } // used for wallmaster manager

    public EnemyDefinition(string type, float x, float y, int count = 1)
    {
        Type = type;
        X = x;
        Y = y;
        this.count = count;
    }
}
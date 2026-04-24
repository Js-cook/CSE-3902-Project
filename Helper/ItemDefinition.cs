using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ItemDefinition
{
    public ItemType Type { get; set; }
    public bool Acquired { get; set; } = false;
    public float X { get; set; }
    public float Y { get; set; }
    public ItemDefinition(ItemType type, float x, float y)
    {
    Type = type;
        X = x;
        Y = y;
    }
}
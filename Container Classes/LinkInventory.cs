using System;
using System.Collections.Generic;

public class LinkInventory
{
    public int keys { get; set; }
    public int maxHearts { get; set; }
    public int currentHearts { get; set; }
    public int rupees { get; set; }
    public int items { get; set; }

    public LinkInventory()
    {
        keys = 0;
        maxHearts = 3;
        currentHearts = 3;
        rupees = 0;
        items = 0;
    }

}
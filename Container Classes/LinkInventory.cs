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
        maxHearts = 3; // maxHearts here refers to the number of whole hearts
        currentHearts = 6; // currentHearts refers to the number of heart halves
        rupees = 0;
        items = 0;
    }

}
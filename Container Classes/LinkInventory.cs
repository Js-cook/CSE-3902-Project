using System;
using System.Collections.Generic;
using Enums;

public class LinkInventory
{
    public int keys { get; set; }
    public int maxHearts { get; set; }
    public int currentHearts { get; set; }
    public int rupees { get; set; }
    public int items { get; set; }
    public bool hasCompass { get; set; }
    public bool hasMap { get; set; }

    public bool hasTriForcePiece { get; set; }
    public Weapon primaryItem { get; set; }
    public Weapon secondaryItem { get; set; }

    public LinkInventory()
    {
        keys = 0;
        maxHearts = 3; // maxHearts here refers to the number of whole hearts
        currentHearts = maxHearts * 2; // currentHearts refers to the number of heart halves
        rupees = 0;
        items = 0;
        hasCompass = false;
        hasMap = false;
        primaryItem = Weapon.WOOD_SWORD;
        secondaryItem = Weapon.BOMB;
        hasTriForcePiece = false;

    }

    public void ResetInventory()
    {
        keys = 0;
        maxHearts = 3; // maxHearts here refers to the number of whole hearts
        currentHearts = maxHearts * 2; // currentHearts refers to the number of heart halves
        rupees = 0;
        items = 0;
        hasCompass = false;
        hasMap = false;
        primaryItem = Weapon.WOOD_SWORD;
        secondaryItem = Weapon.BOMB;
        hasTriForcePiece = false;
    }


}
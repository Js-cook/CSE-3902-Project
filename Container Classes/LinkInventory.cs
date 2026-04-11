using System;
using System.Collections.Generic;
using Enums;

public class LinkInventory
{
    public int keys { get; set; }
    public int maxHearts { get; set; }
    public int currentHearts { get; set; }
    public int rupees { get; set; }
    
    //public int items { get; set; }
    public int bombs { get; set; }
    public int boomerangs { get; set; }
    public int magicBoomerangs { get; set; }
    public int arrows { get; set; }
    

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
        //items = 0;
        bombs = 3;
        boomerangs = 0;
        magicBoomerangs = 0;
        arrows = 0;
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
        bombs = 3;
        boomerangs = 0;
        magicBoomerangs = 0;
        arrows = 0;
        hasCompass = false;
        hasMap = false;
        primaryItem = Weapon.WOOD_SWORD;
        secondaryItem = Weapon.BOMB;
        hasTriForcePiece = false;
    }

    public int calculateNumberOfSecondaryItems()
    {
        switch (secondaryItem)
        {
            case Weapon.ARROW:
                return arrows;
            case Weapon.SILVER_ARROW:
                //return playerInventory.arrows;
                return 0;
            case Weapon.BOMB:
                return bombs;
            case Weapon.BOOMERANG:
                return boomerangs;
            case Weapon.MAGIC_BOOMERANG:
                return magicBoomerangs;
            case Weapon.NONE:
                return 0;
            default:
                return 0;
        }
    }

    public void useSecondaryItem()
    {
        switch (secondaryItem)
        {
            case Weapon.ARROW:
                arrows--;
                break;
            case Weapon.SILVER_ARROW:
                //if (playerInventory.arrows > 0)
                //{
                //    playerInventory.arrows--;
                //}
                break;
            case Weapon.BOMB:
                bombs--;
                break;
            case Weapon.BOOMERANG:
            case Weapon.NONE:
            default:
                break;
        }
    }

}
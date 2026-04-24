using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Enums;

public class ItemController
{     
    public List<PickupItem> itemArray { get; set; } = new List<PickupItem>();

    private ItemFactory itemFactory;
    private Dictionary<string, SoundEffect> sfx;
    private AudioController audioController = new();

    public ItemController(ItemFactory itemFactory, Dictionary<string, SoundEffect> sfx)
    {
        this.itemFactory = itemFactory;
        this.sfx = sfx;
    }

    public void SpawnItem(ItemType itemType, Vector2 position)
    {
        ISprite sprite = itemType switch
        {
            ItemType.Heart => itemFactory.CreateHeartSprite(),
            ItemType.Rupee => itemFactory.CreateRupeeSprite(),
            ItemType.Key => itemFactory.CreateKeySprite(),
            ItemType.Bomb => itemFactory.CreateStaticBombSprite(),
            ItemType.Arrow => itemFactory.CreateStaticArrowSprite(),
            ItemType.HeartContainer => itemFactory.CreateHeartContainerSprite(),
            ItemType.TriForcePiece => itemFactory.CreateTriForcePieceSprite(),
            ItemType.Compass => itemFactory.CreateCompassSprite(),
            ItemType.Map => itemFactory.CreateMapSprite(),
            ItemType.Bow => itemFactory.CreateBowSprite(),
            ItemType.WoodenBoomerang => itemFactory.CreateWoodenBoomerangSprite(),
            ItemType.Fairy => itemFactory.CreateFairySprite(),
            ItemType.Clock => itemFactory.CreateClockSprite(),
            ItemType.RedRing => itemFactory.CreateRedRingSprite(),
            ItemType.PowerBracelet => itemFactory.CreatePowerBraceletSprite(),
            _ => null
        };

        if (sprite != null)
        {
            var item = new PickupItem(sprite, position, itemType);
            itemArray.Add(item);
        }
    }

    // Overload to spawn an item with room/grid coordinates so we can persist pickups
    public void SpawnItem(ItemType itemType, Vector2 position, int roomRow, int roomCol, float gridX, float gridY)
    {
        ISprite sprite = itemType switch
        {
            ItemType.Heart => itemFactory.CreateHeartSprite(),
            ItemType.Rupee => itemFactory.CreateRupeeSprite(),
            ItemType.Key => itemFactory.CreateKeySprite(),
            ItemType.Bomb => itemFactory.CreateStaticBombSprite(),
            ItemType.Arrow => itemFactory.CreateStaticArrowSprite(),
            ItemType.HeartContainer => itemFactory.CreateHeartContainerSprite(),
            ItemType.TriForcePiece => itemFactory.CreateTriForcePieceSprite(),
            ItemType.Compass => itemFactory.CreateCompassSprite(),
            ItemType.Map => itemFactory.CreateMapSprite(),
            ItemType.Bow => itemFactory.CreateBowSprite(),
            ItemType.WoodenBoomerang => itemFactory.CreateWoodenBoomerangSprite(),
            ItemType.Fairy => itemFactory.CreateFairySprite(),
            ItemType.Clock => itemFactory.CreateClockSprite(),
            ItemType.RedRing => itemFactory.CreateRedRingSprite(),
            ItemType.PowerBracelet => itemFactory.CreatePowerBraceletSprite(),
            _ => null
        };

        if (sprite != null)
        {
            var item = new PickupItem(sprite, position, itemType)
            {
                RoomRow = roomRow,
                RoomCol = roomCol,
                GridX = gridX,
                GridY = gridY
            };
            itemArray.Add(item);
        }
    }

    public void ClearItems()
    {
        itemArray.Clear();
    }

    public void AddItem(PickupItem item)
    {
        itemArray.Add(item);
    }

    public void Update(GameTime gameTime)
    {
        for (int i = itemArray.Count - 1; i >= 0; i--)
        {
            var item = itemArray[i];
            if (!item.HitboxActive)
            {
                if (sfx != null && sfx.ContainsKey("ItemPickup"))
                {
                    audioController.PlaySoundEffect(sfx["ItemPickup"], 0.75f);
                }
                itemArray.RemoveAt(i);
            }
            else
            {
                item.Update(gameTime);
            }
        }
    }

    public void Draw()
    {
        foreach (var item in itemArray)
        {
            item.Draw();
        }
    }

    public List<PickupItem> GetAllItems()
    {
        return itemArray;
    }
}
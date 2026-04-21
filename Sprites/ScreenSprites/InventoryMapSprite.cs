using Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class InventoryMapSprite : ISprite
{
    private Texture2D texture;
    private SpriteBatch spriteBatch;
    private HUDSpriteFactory spriteFactory;

    // Ordering goes left, right, top, bottom
    private Dictionary<string, Vector2> roomTiles = new()
    {
        { "Right", new Vector2(528, 108) },
        { "Left", new Vector2(537, 108) },
        { "LeftRight", new Vector2(546, 108) },
        { "Bottom", new Vector2(555, 108) },
        { "RightBottom", new Vector2(564, 108) },
        { "LeftBottom", new Vector2(573, 108) },
        { "LeftRightBottom", new Vector2(582, 108) },
        { "Top", new Vector2(591, 108) },
        { "RightTop", new Vector2(600, 108) },
        { "LeftTop", new Vector2(609, 108) },
        { "LeftRightTop", new Vector2(618, 108) },
        { "TopBottom", new Vector2(627, 108) },
        { "RightTopBottom", new Vector2(636, 108) },
        { "LeftTopBottom", new Vector2(645, 108) },
        { "LeftRightTopBottom", new Vector2(654, 108) },
    };

    private List<(ISprite, Vector2)> currentTilePositions;

    private LinkInventory playerInventory;

    public RoomInfo CurrentRoomInfo
    {
        get
        {
            var roomVec = playerInventory.currentRoom;
            return RoomsRepository.GetRoomInfo((int)roomVec.X, (int)roomVec.Y);
        }
    }

    public DoorType? GetTopDoorType()
    {
        if (CurrentRoomInfo == null) return null;
        return CurrentRoomInfo.DoorTypes.TryGetValue(Direction.UP, out var t) ? (DoorType?)t : null;
    }

    public DoorType? GetRightDoorType()
    {
        if (CurrentRoomInfo == null) return null;
        return CurrentRoomInfo.DoorTypes.TryGetValue(Direction.RIGHT, out var t) ? (DoorType?)t : null;
    }

    public DoorType? GetBottomDoorType()
    {
        if (CurrentRoomInfo == null) return null;
        return CurrentRoomInfo.DoorTypes.TryGetValue(Direction.DOWN, out var t) ? (DoorType?)t : null;
    }

    public DoorType? GetLeftDoorType()
    {
        if (CurrentRoomInfo == null) return null;
        return CurrentRoomInfo.DoorTypes.TryGetValue(Direction.LEFT, out var t) ? (DoorType?)t : null;
    }

    public InventoryMapSprite(Texture2D texture, SpriteBatch spriteBatch, LinkInventory playerInventory, HUDSpriteFactory spriteFactory)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.playerInventory = playerInventory;
        currentTilePositions = new List<(ISprite, Vector2)>();
        this.spriteFactory = spriteFactory;
    }

    private ISprite DetermineRoomTileSprite()
    {
        string query = "";

        _ = (GetLeftDoorType() == DoorType.OpenDoor || GetLeftDoorType() == DoorType.KeyLockedDoor || GetLeftDoorType() == DoorType.DiamondLockedDoor) ? query += "Left" : query += "";
        _ = (GetRightDoorType() == DoorType.OpenDoor || GetRightDoorType() == DoorType.KeyLockedDoor || GetRightDoorType() == DoorType.DiamondLockedDoor) ? query += "Right" : query += "";
        _ = (GetTopDoorType() == DoorType.OpenDoor || GetTopDoorType() == DoorType.KeyLockedDoor || GetTopDoorType() == DoorType.DiamondLockedDoor) ? query += "Top" : query += "";
        _ = (GetBottomDoorType() == DoorType.OpenDoor || GetBottomDoorType() == DoorType.KeyLockedDoor || GetBottomDoorType() == DoorType.DiamondLockedDoor) ? query += "Bottom" : query += "";

        return spriteFactory.CreateInventoryMapTileSprite(roomTiles[query]);
    }

    private Vector2 RoomCoordsToScreenCoords(Vector2 roomCoords)
    {
        int xOffset = 8*4;
        int yOffset = 8*4;
        int baseX = 560;
        int baseY = 340;
        return new Vector2(baseX + xOffset * roomCoords.X, baseY + yOffset * roomCoords.Y);
    }

    private ISprite DetermineRoomTileSpriteForRoom(int row, int col)
    {
        var roomInfo = RoomsRepository.GetRoomInfo(row, col);
        if (roomInfo == null) return null;

        string query = "";
        _ = (roomInfo.DoorTypes.TryGetValue(Direction.LEFT, out var left) && 
             (left == DoorType.OpenDoor || left == DoorType.KeyLockedDoor || left == DoorType.DiamondLockedDoor)) ? query += "Left" : query += "";
        _ = (roomInfo.DoorTypes.TryGetValue(Direction.RIGHT, out var right) && 
             (right == DoorType.OpenDoor || right == DoorType.KeyLockedDoor || right == DoorType.DiamondLockedDoor)) ? query += "Right" : query += "";
        _ = (roomInfo.DoorTypes.TryGetValue(Direction.UP, out var top) && 
             (top == DoorType.OpenDoor || top == DoorType.KeyLockedDoor || top == DoorType.DiamondLockedDoor)) ? query += "Top" : query += "";
        _ = (roomInfo.DoorTypes.TryGetValue(Direction.DOWN, out var bottom) && 
             (bottom == DoorType.OpenDoor || bottom == DoorType.KeyLockedDoor || bottom == DoorType.DiamondLockedDoor)) ? query += "Bottom" : query += "";

        return spriteFactory.CreateInventoryMapTileSprite(roomTiles[query]);
    }

    public void Update(GameTime gametime)
    {
        currentTilePositions.Clear();

        Debug.WriteLine(playerInventory.VisitedRooms.Count);
        // Add all visited rooms
        foreach (var (row, col) in playerInventory.VisitedRooms)
        {
            var sprite = DetermineRoomTileSpriteForRoom(row, col);
            if (sprite != null)
            {
                currentTilePositions.Add((sprite, RoomCoordsToScreenCoords(new Vector2(col, row))));
            }
        }
    }

    public void SpriteDraw(Vector2 position)
    {
        foreach((ISprite sprite, Vector2 v) in currentTilePositions)
        {
            sprite.SpriteDraw(v);
        }
    }
}
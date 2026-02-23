using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Environment
{
    private List<ISprite> tiles;
    private int currentTileIndex;
    private Vector2 position;

    public Environment(TileFactory factory)
    {
        // arbitrary starting position
        position = new Vector2(200, 200);
        currentTileIndex = 0;

        tiles = new List<ISprite>();
        tiles.Add(factory.CreateStatueSprite());
        tiles.Add(factory.CreateSquareBlockSprite());
        tiles.Add(factory.CreateBlueGapSprite());
        tiles.Add(factory.CreateStairSprite());
        tiles.Add(factory.CreateWhiteBrickSprite());
        tiles.Add(factory.CreateLadderSprite());
        tiles.Add(factory.CreateBlueFloorSprite());
        tiles.Add(factory.CreateBlueSandSprite());
        tiles.Add(factory.CreateWallSprite());
        tiles.Add(factory.CreateBombedWallSprite());
        tiles.Add(factory.CreateKeyLockedDoorSprite());
        tiles.Add(factory.CreateDiamondLockedDoorSprite());
        tiles.Add(factory.CreateOpenDoorSprite());

    }

    public void CycleRight()
    {
        currentTileIndex++;
        if (currentTileIndex >= tiles.Count)
            currentTileIndex = 0;
    }

    public void CycleLeft()
    {
        currentTileIndex--;
        if (currentTileIndex < 0)
            currentTileIndex = tiles.Count - 1;
    }

    public void CycleReset()
    {
        currentTileIndex = 0;
    }

    public void Update(GameTime gameTime)
    {
        tiles[currentTileIndex].Update(gameTime);
    }

    public void Draw()
    {
        tiles[currentTileIndex].SpriteDraw(position);
    }
}
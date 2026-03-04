using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System.Collections.Generic;

public class FactoryStorage
{
    private Texture2D playerTexture;
    private Texture2D tileTexture;
    private Texture2D itemTexture;

    public PlayerSpriteFactory playerSpriteFactory { get; }
    public ProjectileSpriteFactory projectileSpriteFactory { get; }
    public TileFactory tileFactory { get; }
    public ItemFactory itemFactory { get; }

    public FactoryStorage(Texture2D playerTexture, Texture2D tileTextures, Texture2D itemTextures, SpriteBatch sb)
    {
        this.playerTexture = playerTexture;
        playerSpriteFactory = new PlayerSpriteFactory(playerTexture, sb);
        projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, sb);
        tileFactory = new TileFactory(tileTextures, playerTexture, sb);
        itemFactory = new ItemFactory(itemTextures, sb);
    }
    
}

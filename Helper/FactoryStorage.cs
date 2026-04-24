using Microsoft.Xna.Framework.Graphics;
using Sprites;

public class FactoryStorage
{
    private Texture2D playerTexture;
    private Texture2D enemyTexture;
    private Texture2D tileTexture;
    private Texture2D itemTexture;
    private Texture2D treasureChestTexture;
    private Texture2D npcTexture;

    public PlayerSpriteFactory playerSpriteFactory { get; }
    public ProjectileSpriteFactory projectileSpriteFactory { get; }
    public TileFactory tileFactory { get; }
    public ItemFactory itemFactory { get; }

    public FactoryStorage(
        Texture2D playerTexture,
        Texture2D enemyTexture,
        Texture2D tileTexture,
        Texture2D itemTexture,
        Texture2D treasureChestTexture,
        Texture2D npcTexture,
        SpriteBatch sb)
    {
        this.playerTexture = playerTexture;
        this.enemyTexture = enemyTexture;
        this.tileTexture = tileTexture;
        this.itemTexture = itemTexture;
        this.treasureChestTexture = treasureChestTexture;
        this.npcTexture = npcTexture;

        playerSpriteFactory = new PlayerSpriteFactory(playerTexture, sb);
        projectileSpriteFactory = new ProjectileSpriteFactory(playerTexture, sb);
        tileFactory = new TileFactory(tileTexture, playerTexture, enemyTexture, treasureChestTexture, npcTexture, sb);
        itemFactory = new ItemFactory(itemTexture, sb);
    }
}
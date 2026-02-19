using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class UpAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;
    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private bool animationDone = false;
    
    public UpAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
    {
        this.player = player;
        this.spriteFactory = spriteFactory;
    }
    public void ChangeDirection(Direction Direction)
    {
        // do nothing - can't change direction while attacking
    }
    public void BeDead()
    {
    }
    public void BeDamaged()
    {
        player.Hurt = true;
    }
    public void BeAttacking()
    {
    }
    public void FireArrow()
    {
    }
    public void FireSilverArrow()
    {
    }
    public void FireBoomerang()
    {
    }
    public void FireMagicBoomerang()
    {
    }
    public void FireFireball()
    {
    }
    public void FireBomb()
    {
    }
    public void BeIdle()
    {
        if (animationDone)
        {
            //animationDone = false;
            player.playerState = new UpIdlePlayerState(player, spriteFactory);
            player.Sprite = spriteFactory.CreateUpIdlePlayerSprite(player.position);
        }
    }
    public void Update(GameTime gametime)
    {
        startClock += gametime.ElapsedGameTime.TotalSeconds;
        if (startClock >= animationDuration)
        {
            animationDone = true;
            BeIdle();
        }
    }
}

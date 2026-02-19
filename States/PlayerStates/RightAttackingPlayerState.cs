using Enums;
using Microsoft.Xna.Framework;
using Sprites;

public class RightAttackingPlayerState : Interfaces.IPlayerState
{
    private Link player;
    private PlayerSpriteFactory spriteFactory;

    private double startClock = 0.0;
    private double animationDuration = 0.4;

    private bool animationDone = false;

    public RightAttackingPlayerState(Link player, PlayerSpriteFactory spriteFactory)
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
            player.playerState = new RightIdlePlayerState(player, spriteFactory);
            player.Sprite = spriteFactory.CreateRightIdlePlayerSprite(player.position);
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


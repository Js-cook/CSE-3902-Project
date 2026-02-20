using Interfaces;
using Microsoft.Xna.Framework;
using Sprites;
using System.Collections.Generic;
using Controllers;

public class Link
{
    public Vector2 position { get; set; }
    public IPlayerSprite Sprite { get; set; }
    public IPlayerState playerState { get; set; }
    private PlayerSpriteFactory spriteFactory;
    public ProjectileSpriteFactory projectileSpriteFactory { get; set; }

    public bool Hurt { get; set; }
    private double hurtTimer = 0.0;
    private double hurtDuration = 2.5;

    public List<IProjectile> projectiles { get; set; } = new List<IProjectile>();

    public Link(PlayerSpriteFactory spriteFactory, ProjectileSpriteFactory projectileSpriteFactory, ProjectileController projectileController)
    {
        position = new Vector2(10, 10); // arbitrary starting position - change later
        playerState = new RightIdlePlayerState(this, spriteFactory, projectileController);
        Sprite = spriteFactory.CreateRightIdlePlayerSprite(position);
        this.projectileSpriteFactory = projectileSpriteFactory;
    }

    public void MoveUp() 
    {
        position = new Vector2(position.X, position.Y - 1);
    }

    public void MoveDown()
    {
        position = new Vector2(position.X, position.Y + 1);
    }

    public void MoveLeft()
    {
        position = new Vector2(position.X - 1, position.Y);
    }
    public void MoveRight()
    {
        position = new Vector2(position.X + 1, position.Y);
    }

    public void Update(GameTime gametime)
    {
        playerState.Update(gametime);
        Sprite.Update(gametime);
        List<IProjectile> markedForDeletion = new List<IProjectile>();

        if (Hurt)
        {
            hurtTimer += gametime.ElapsedGameTime.TotalSeconds;
            if(hurtTimer >= hurtDuration)
            {
                Hurt = false;
                hurtTimer = 0.0;
            }
        }

        //foreach (IProjectile projectile in projectiles)
        //{
        //    if (!projectile.Active)
        //    {
        //        markedForDeletion.Add(projectile);

        //    }
        //    projectile.Update(gametime);
        //}

        //foreach (IProjectile projectile in markedForDeletion)
        //{
        //    projectiles.Remove(projectile);
        //    if(projectile is Arrow || projectile is SilverArrow)
        //    {
        //        projectiles.Add(new ArrowParticle(projectile.Position, projectileSpriteFactory));
        //    }
        //    if(projectile is Bomb)
        //    {
        //        projectiles.Add(new BombParticle(projectile.Position, projectileSpriteFactory));
        //    }
        //}

    }

    public void Draw()
    {
        Sprite.Hurt = Hurt;
        Sprite.SpriteDraw(position);
        //foreach (IProjectile projectile in projectiles)
        //{
        //    projectile.Draw();
        //}
    }
}


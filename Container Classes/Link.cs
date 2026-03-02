using Interfaces;
using Microsoft.Xna.Framework;
using Sprites;
using System.Collections.Generic;
using Controllers;
using Microsoft.Xna.Framework.Audio;

public class Link : ICollidable
{

    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, 16, 16);
        }
    }
    public Vector2 position { get; set; }
    public IPlayerSprite Sprite { get; set; }
    public IPlayerState playerState { get; set; }
    public ProjectileSpriteFactory projectileSpriteFactory { get; set; }

    public bool Hurt { get; set; }
    private double hurtTimer = 0.0;
    private double hurtDuration = 2.5;

    public List<IProjectile> projectiles { get; set; } = new List<IProjectile>();

    public Link(PlayerSpriteFactory spriteFactory, ProjectileSpriteFactory projectileSpriteFactory, ProjectileController projectileController, Dictionary<string, SoundEffect> soundEffect)
    {
        position = new Vector2(10, 10); // arbitrary starting position - change later
        playerState = new RightIdlePlayerState(this, spriteFactory, projectileController, soundEffect);
        this.projectileSpriteFactory = projectileSpriteFactory;
        Sprite = spriteFactory.CreateRightIdlePlayerSprite(position);
    }

    public void MoveUp() 
    {
        position = new Vector2(position.X, position.Y - 2);
    }

    public void MoveDown()
    {
        position = new Vector2(position.X, position.Y + 2);
    }

    public void MoveLeft()
    {
        position = new Vector2(position.X - 2, position.Y);
    }
    public void MoveRight()
    {
        position = new Vector2(position.X + 2, position.Y);
    }

    public void Update(GameTime gametime)
    {
        playerState.Update(gametime);
        Sprite.Update(gametime);
        //List<IProjectile> markedForDeletion = new List<IProjectile>();

        if (Hurt)
        {
            hurtTimer += gametime.ElapsedGameTime.TotalSeconds;
            if(hurtTimer >= hurtDuration)
            {
                Hurt = false;
                hurtTimer = 0.0;
            }
        }
    }

    public void Draw()
    {
        Sprite.Hurt = Hurt;
        Sprite.SpriteDraw(position);
    }
}


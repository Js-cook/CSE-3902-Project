using Interfaces;
using Microsoft.Xna.Framework;
using System.Diagnostics;

public class SpikeTile : ICollidable
{
    public ISprite Sprite { get; set; }
    public Vector2 Position { get; set; }
    public bool HitboxActive { get; set; } = true;

    public float DamageValue { get; set; } = Settings.Instance.SpikeTileDamageValue;

    public Vector2 OriginalPosition {  get; private set; }

    public Link TargetPlayer {  get; private set; }
    public ISpiketrapState spiketrapState { get; set; }


    public Rectangle Hitbox
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 64, 64);
        }
    }

    public SpikeTile(ISprite sprite, Vector2 position, Link player)
    {
        Sprite = sprite;
        Position = position;
        spiketrapState = new IdleSpiketrapState(this);

        TargetPlayer = player;
        OriginalPosition = position;
    }

    public void ChangeState(ISpiketrapState newState)
    {
        spiketrapState = newState;
    }

    public void Update(GameTime gameTime)
    {
        spiketrapState.Update(gameTime);
    }

    public void OnWallCollision()
    {
        spiketrapState.OnWallCollision();
    }
}


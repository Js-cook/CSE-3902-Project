using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DeathCloud : IEffect
{
   
    public Vector2 Position { get; set; }

    private double startTime = 0.0;
    private double duration = 0.6;
    private ISprite sprite;
    public bool IsExpired { get; set; }

    public DeathCloud(Vector2 position, EffectSpriteFactory effectSpriteFactory)
    {
        Position = position;
        sprite = effectSpriteFactory.CreateDeathCloudSprite(position);
        IsExpired = false;
    }

    public void Draw()
    {
        sprite.SpriteDraw(Position);
    }

    public void Update(GameTime gametime)
    {
        sprite.Update(gametime);
        startTime += gametime.ElapsedGameTime.TotalSeconds;

        if (startTime >= duration)
        {
            // do something to delete particle
            IsExpired = true;

        }
    }

    public void OnCollision()
    {
        // do nothing, particle should not interact with anything
    }
}

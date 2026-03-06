using Microsoft.Xna.Framework;


/// <summary>
/// Factory class for creating enemy instances. It takes in the necessary sprite factories and graphics device manager to create enemies with the correct sprites and graphics settings.
/// </summary>
public class EffectFactory
{
    private EffectSpriteFactory effectSpriteFactory;
  

    public EffectFactory(EffectSpriteFactory effectSpriteFactory)
    {
        this.effectSpriteFactory = effectSpriteFactory;
      
    }

   public DeathCloud CreateDeathCloud(Vector2 position)
    {
        return new DeathCloud(position, effectSpriteFactory);
    }

}
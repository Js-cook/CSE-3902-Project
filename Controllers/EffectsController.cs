using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Security.Cryptography;

public class EffectController
{
    private List<IEffect> effects;
    private EffectFactory effectFactory;
    public static EffectController Instance { get; private set; }


    public EffectController(EffectFactory effectFactory)
    {
        effects = new List<IEffect>();
        this.effectFactory = effectFactory;
        Instance = this;
    }


    public  void Update(GameTime gameTime)
    {
        foreach (var effect in effects) effect.Update(gameTime);

        // Remove once the animation finishes
        effects.RemoveAll(e => e.IsExpired);
    }

    public  void Draw()
    {
        foreach (var effect in effects) effect.Draw();
    }

    public void SpawnDeathCloud(Vector2 position)
    {
        effects.Add(effectFactory.CreateDeathCloud(position));
    }

    public  void ClearEffects()
    {
        effects.Clear();
    }
}
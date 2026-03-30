using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

public class SFXLoader
{
    public static Dictionary<string, SoundEffect> LoadPlayerSFX(ContentManager content)
    {
        Dictionary<string, SoundEffect> res = new()
        {
            { "ArrowBoomerang", content.Load<SoundEffect>("SFX/ArrowBoomerang") },
            { "BombDrop", content.Load<SoundEffect>("SFX/BombDrop") },
            { "BombExplode", content.Load<SoundEffect>("SFX/BombExplode") },
            { "SwordSlash", content.Load<SoundEffect>("SFX/SwordSlash") },
            { "EnemyDie", content.Load<SoundEffect>("SFX/EnemyDie") }
        };

        return res;
    }
}
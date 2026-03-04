using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public static class ContentLoaderHelper
{
    public static Dictionary<string, SoundEffect> LoadPlayerSFX(ContentManager Content)
    {
        Dictionary<string, SoundEffect> res = new()
            {
                { "ArrowBoomerang", Content.Load<SoundEffect>("SFX/ArrowBoomerang") },
                { "BombDrop", Content.Load<SoundEffect>("SFX/BombDrop") },
                { "BombExplode", Content.Load<SoundEffect>("SFX/BombExplode") },
                { "SwordSlash", Content.Load<SoundEffect>("SFX/SwordSlash") }
            };

        return res;
    }
}
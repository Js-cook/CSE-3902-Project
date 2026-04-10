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
            { "EnemyDie", content.Load<SoundEffect>("SFX/EnemyDie") },
            { "PlayerDying", content.Load<SoundEffect>("SFX/DyingPlayerSound") },
            { "PlayerDeath", content.Load<SoundEffect>("SFX/DeadPlayerSound")  },
            { "ItemPickup", content.Load<SoundEffect>("SFX/ItemPickupSound")   },
            { "WinSoundEffect", content.Load<SoundEffect>("SFX/WinSoundEffect")  },
            // Door sounds - using placeholder sounds until actual door sounds are added
            { "DoorUnlock", content.Load<SoundEffect>("SFX/ItemPickupSound") }, // TODO: Replace with actual door unlock sound
            { "DoorLocked", content.Load<SoundEffect>("SFX/BombDrop") }, // TODO: Replace with actual locked door sound
        };

        return res;
    }
}
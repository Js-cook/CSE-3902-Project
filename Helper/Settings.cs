using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class Settings
{
    public int scale = 4;

    public float SkeletonSpeed = 3f;
    public float GoriyaSpeed = 2f;
    public float BatSpeed = 4f;
    public float AquamentusSpeed = 1.5f;
    public float GelSpeed = 3f;
    public float PlayerSpeed = 2f;

    public float AquamentusFireballSpeed = 4f;
    public float WinScreenTextSize = 16f;

    public float GoriyaKnockbackSpeed = 6f;
    public float GoriyaKnockbackDuration = 0.4f;

    public float StartingPlayerHealth = 3f;

    public float FairyFlySpeed = 10f;

    public int HEALTH_PER_HEART = 2;

    public static Settings Instance { get; private set; } = new Settings();
}

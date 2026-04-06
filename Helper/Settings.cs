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
    public float PlayerSpeed = 1.5f;

    public float GoriyaKnockbackSpeed = 6f;
    public float GoriyaKnockbackDuration = 0.4f;

    public float StartingPlayerHealth = 1f;

    public static Settings Instance { get; private set; } = new Settings();
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

public class IFrameManager
{
    private double timer = 0;
    private double maxDuration;

    public bool IsInvincible => timer > 0;

    public IFrameManager(double maxDuration)
    {
        this.maxDuration = maxDuration;
    }

    public void Update(GameTime gameTime)
    {
        if (timer > 0)
        {
            Debug.WriteLine("I-Frames active, time remaining: " + timer);
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public void Trigger()
    {
        timer = maxDuration;
    }

   
}
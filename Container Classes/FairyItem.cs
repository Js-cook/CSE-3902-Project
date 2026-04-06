using Microsoft.Xna.Framework;
using Interfaces;
using Enums;
using System;

public class FairyItem : PickupItem
{
    private double timer;
    private double directionTimerMax = 2.0; // Time in seconds before changing direction

    private Vector2 velocity;

    private Random randInt;

    public FairyItem(Vector2 position, ISprite sprite, ItemType itemType) : base(sprite, position, itemType)
    {
        randInt = new Random();
        SetVelocity(new Vector2(1, 1)); // Initial velocity
        timer = 0;
    }

    public void Update(GameTime gameTime)
    {
        if (Sprite != null)
        {
            Sprite.Update(gameTime);
        }

        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= directionTimerMax)
        {
            SetVelocity(new Vector2(randInt.Next(0, 2), randInt.Next(0, 2))); // Randomly change direction but cannot be (0,0)

            timer = 0;
        }
    }

    private void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    
}

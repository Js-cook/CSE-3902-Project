using Microsoft.Xna.Framework;

public class Aquamentus : IEnemy
{

    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IEnemyState aquamentusState { get; set; }


    public AquamentusFireball topFireball { get; set; }
    public AquamentusFireball middleFireball { get; set; }

    public AquamentusFireball bottomFireball { get; set; }





    public Aquamentus(AquamentusSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, BossProjectileSpriteFactory enemyProjectileSpriteFactory)
    {
        position = new Vector2(80, 70); // arbitrary starting position - change later
        aquamentusState = new MovingAquamentusState(this, spriteFactory, _graphics);
        Sprite = spriteFactory.CreateMovingAquamentusSprite(position);

            topFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, -1));
            middleFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, 0));
            bottomFireball = new AquamentusFireball(this.position, enemyProjectileSpriteFactory, new Vector2(-1, 1));
    }

    public void Update(GameTime gametime)
    {
        aquamentusState.Update(gametime);
        Sprite.Update(gametime);

        // Code block to update each fireball separately, only if they are active
        if (topFireball.Active)
            topFireball.Update(gametime);
        if (middleFireball.Active)
            middleFireball.Update(gametime);
        if (bottomFireball.Active)
            bottomFireball.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);

        // Code block to draw each fireball separately, only if they are active
        if (topFireball.Active)
            topFireball.Draw();
        if (middleFireball.Active)
            middleFireball.Draw();
        if (bottomFireball.Active)
            bottomFireball.Draw();
    }

}

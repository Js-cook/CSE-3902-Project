using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class Goriya : IEnemy
{
    public Vector2 position { get; set; }
    // idk if this should be public
    public IEnemyState goriyaState { get; set; }

    public ISprite Sprite;

    public GoriyaBoomerang goriyaBoomerang;





    public Goriya(GoriyaSpriteFactory spriteFactory, GraphicsDeviceManager _graphics, EnemyProjectileSpriteFactory enemyProjectileSpriteFactory)
    {
        position = new Vector2(40, 30); // arbitrary starting position - change later
        goriyaState = new LeftMovingGoriyaState(this, spriteFactory, _graphics);

        // Give Goriya a boomerang to throw
        goriyaBoomerang = new GoriyaBoomerang(this.position, "left", enemyProjectileSpriteFactory);
       

    }

    public void Update(GameTime gametime)
    {
        goriyaState.Update(gametime);
        Sprite.Update(gametime);
        if (goriyaBoomerang.Active)
            goriyaBoomerang.Update(gametime);


    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
        if (goriyaBoomerang.Active)
            goriyaBoomerang.Draw();
       

    }

}
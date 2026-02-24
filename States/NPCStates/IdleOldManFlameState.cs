using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleOldManFlameState : IEnemyState
{
    private OldManFlame oldManFlame;
    private OldManFlameSpriteFactory spriteFactory;
    GraphicsDeviceManager _graphics;
    public IdleOldManFlameState(OldManFlame oldManFlame, OldManFlameSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        this.oldManFlame = oldManFlame;
        this.spriteFactory = spriteFactory;

        this._graphics = _graphics;

    }
    public void ChangeDirection()
    {
        // No need for this 
    }
    public void BeDead()
    {
        //No need for this

    }
    public void Update(GameTime gameTime)
    {
        // Idle


    }


}

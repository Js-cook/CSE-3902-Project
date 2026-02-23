using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleOldManState : IEnemyState
{
    private OldMan oldMan;
    private OldManSpriteFactory spriteFactory;
    GraphicsDeviceManager _graphics;
    public IdleOldManState(OldMan oldMan, OldManSpriteFactory spriteFactory, GraphicsDeviceManager _graphics)
    {
        this.oldMan = oldMan;
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

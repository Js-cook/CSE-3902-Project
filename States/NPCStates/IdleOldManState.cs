using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Enums;

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
    }
    public void BeDead()
    {
    }
    public void Update(GameTime gameTime)
    {
    }
    public void TakeDamage()
    {
    }
    public void OnWallCollision(Enums.Direction newDir)
    {
    }
}

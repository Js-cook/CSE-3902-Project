using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovingGelState : IEnemyState
{
    private Gel gel;
    private GelSpriteFactory spriteFactory;
    public MovingGelState(Gel gel, GelSpriteFactory gelSpriteFactory)
    {
        this.gel = gel;
        this.spriteFactory = gelSpriteFactory;

    }

    public void ChangeDirection()
    {
        // No need for this 
    }

    public void BeDead()
    {

        //No need for this
        
    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        gel.position.X += 1;

    }   
}
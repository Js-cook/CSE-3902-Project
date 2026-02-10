using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Link
{
    public Vector2 position { get; set; }
    public ISprite Sprite { get; set; }
    // idk if this should be public
    public IPlayerState playerState { get; set; }
    private PlayerSpriteFactory spriteFactory;


    public Link(PlayerSpriteFactory spriteFactory)
    {
        position = new Vector2(10, 10); // arbitrary starting position - change later
        playerState = new RightIdlePlayerState(this, spriteFactory);
        Sprite = spriteFactory.CreateRightMovingPlayerSprite(position);
    }

    public void MoveUp() 
    {
        position = new Vector2(position.X, position.Y - 1);
    }

    public void MoveDown()
    {
        position = new Vector2(position.X, position.Y + 1);
    }

    public void MoveLeft()
    {
        position = new Vector2(position.X - 1, position.Y);
    }
    public void MoveRight()
    {
        position = new Vector2(position.X + 1, position.Y);
    }

    public void Update(GameTime gametime)
    {
        playerState.Update(gametime);
        Sprite.Update(gametime);
    }

    public void Draw()
    {
        Sprite.SpriteDraw(position);
    }
}


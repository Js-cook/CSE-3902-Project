using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GoriyaAttackState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;
    private GraphicsDeviceManager _graphics;
    private string direction;
    public GoriyaAttackState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics, string direction)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        this._graphics = _graphics;
        // The sprite can be set to any direction since the boomerang will be active and the Goriya will be stationary during the attack.
        switch (direction)
        {
            case "left":
                goriya.Sprite = spriteFactory.CreateLeftMovingGoriyaSprite(goriya.position);
                break;
            case "right":
                goriya.Sprite = spriteFactory.CreateRightMovingGoriyaSprite(goriya.position);
                break;
            case "up":
                goriya.Sprite = spriteFactory.CreateUpMovingGoriyaSprite(goriya.position);
                break;
            case "down":
                goriya.Sprite = spriteFactory.CreateDownMovingGoriyaSprite(goriya.position);
                break;
        }
        this.direction = direction;
    }
    public void ChangeDirection()
    {
        // No movement during attack, so no direction change.
    }
    public void BeDead()
    {
        // No need for this
    }
    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        // During the attack state, the Goriya should not move. It should only transition back to a moving state once the boomerang is no longer active.
        if (!goriya.goriyaBoomerang.Active)
        {
            // Transition back to a moving state based on the previous direction.
            switch (direction)
            {
                case "left":
                    goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "right":
                    goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "up":
                    goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
                case "down":
                    goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                    break;
            }
        }
    }
}

public class LeftMovingGoriyaState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;


    double timerMax = 2;
    double timer;

    double shootTimerMax = 3;
    double shootTimer;

    int speed = 2;
    private Vector2 velocity;
    private Random randInt;

    public bool isAttacking = false;

    private GraphicsDeviceManager _graphics;
    public LeftMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateLeftMovingGoriyaSprite(goriya.position);
        timer = 0;
        shootTimer = 0;

        velocity = new Vector2(-1, 0) * speed;
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(3);

        switch (choice)
        {
            // Down
            case 0:
                goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Up
            case 1:
                goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Right
            case 2:
                goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
        }

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {

        

        // Rnadom movement logic
        goriya.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }

        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
        }

       


        EnemyHelper.CheckBounds(ref velocity, goriya.position, _graphics);
        ChangeState(); // This will adjust the state if the velocity changes due to bounds checking, ensuring the correct sprite is displayed.

    }

    private void ChangeState()
    {
       
        if (velocity.X > 0)
        {
            goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.Y < 0)
        {
            goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.Y > 0)
        {
            goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "left");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "left");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired

        
    }

}

public class DownMovingGoriyaState : IEnemyState {

    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double timerMax = 5;
    double timer;
    int speed = 2;

    double shootTimerMax = 3;
    double shootTimer;

    private Vector2 velocity;
    private Random randInt;
    public bool isAttacking = false;


    private GraphicsDeviceManager _graphics;
    public DownMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateDownMovingGoriyaSprite(goriya.position);
        timer = 0;

        shootTimer = 0;

        velocity = new Vector2(0, 1) * speed;
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(3);

        switch (choice)
        {
            // Down
            case 0:
                goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Up
            case 1:
                goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Right
            case 2:
                goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
        }

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        goriya.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }

        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
        }


       


        EnemyHelper.CheckBounds(ref velocity, goriya.position, _graphics);
        ChangeState(); // This will adjust the state if the velocity changes due to bounds checking, ensuring the correct sprite is displayed.
    }

    private void ChangeState()
    {
        if (velocity.X < 0)
        {
            goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.X > 0)
        {
            goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.Y < 0)
        {
            goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        
    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "down");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "down");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

}

public class UpMovingGoriyaState : IEnemyState
{
    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double timerMax = 5;
    double timer;
    int speed = 2;

    double shootTimerMax = 3;
    double shootTimer;

    private Vector2 velocity;
    private Random randInt;
    public bool isAttacking = false;


    private GraphicsDeviceManager _graphics;
    public UpMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateUpMovingGoriyaSprite(goriya.position);
        timer = 0;

        shootTimer = 0;

        velocity = new Vector2(0, -1) * speed;
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(3);

        switch (choice)
        {
            // Down
            case 0:
                goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Up
            case 1:
                goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Right
            case 2:
                goriya.goriyaState = new RightMovingGoriyaState(goriya,spriteFactory, _graphics);
                break;
        }

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        goriya.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }

        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
        }


       

        EnemyHelper.CheckBounds(ref velocity, goriya.position, _graphics);
        ChangeState(); // This will adjust the state if the velocity changes due to bounds checking, ensuring the correct sprite is displayed.
    }

    private void ChangeState()
    {
        if (velocity.X < 0)
        {
            goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.X > 0)
        {
            goriya.goriyaState = new RightMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
       
        if (velocity.Y > 0)
        {
            goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "up");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "up");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

}

public class RightMovingGoriyaState : IEnemyState {

    private Goriya goriya;
    private GoriyaSpriteFactory spriteFactory;

    double timerMax = 5;
    double timer;
    int speed = 2;

    double shootTimerMax = 3;
        double shootTimer;

    private Vector2 velocity;
    private Random randInt;
    public bool isAttacking = false;


    private GraphicsDeviceManager _graphics;
    public RightMovingGoriyaState(Goriya goriya, GoriyaSpriteFactory goriyaSpriteFactory, GraphicsDeviceManager _graphics)
    {
        this.goriya = goriya;
        this.spriteFactory = goriyaSpriteFactory;
        goriya.Sprite = spriteFactory.CreateRightMovingGoriyaSprite(goriya.position);
        timer = 0;

        shootTimer = 0;
        velocity = new Vector2(1, 0) * speed;
        randInt = new Random();
        this._graphics = _graphics;

    }

    public void ChangeDirection()
    {
        int choice = randInt.Next(3);

        switch (choice)
        {
            // Down
            case 0:
                goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Up
            case 1:
                goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
            // Right
            case 2:
                goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
                break;
        }

    }

    public void BeDead()
    {

        //No need for this

    }

    public void Update(Microsoft.Xna.Framework.GameTime gameTime)
    {
        goriya.position += velocity;
        timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= timerMax)
        {
            ChangeDirection();
            timer = 0;
        }

        shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (shootTimer >= shootTimerMax)
        {
            FireBoomerang();
            shootTimer = 0;
        }

     


        // adjsuting state depending on velocity for any other case



        EnemyHelper.CheckBounds(ref velocity, goriya.position, _graphics);
        ChangeState(); // This will adjust the state if the velocity changes due to bounds checking, ensuring the correct sprite is displayed.
    }

    private void ChangeState()
    {
        if (velocity.X < 0)
        {
            goriya.goriyaState = new LeftMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        
        if (velocity.Y < 0)
        {
            goriya.goriyaState = new UpMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
        if (velocity.Y > 0)
        {
            goriya.goriyaState = new DownMovingGoriyaState(goriya, spriteFactory, _graphics);
        }
    }

    public void FireBoomerang()
    {
        goriya.goriyaState = new GoriyaAttackState(goriya, spriteFactory, _graphics, "right");
        goriya.goriyaBoomerang.ResetBoomerang(goriya.position, "right");
        goriya.goriyaBoomerang.Active = true; // Activate the boomerang when fired
    }

}






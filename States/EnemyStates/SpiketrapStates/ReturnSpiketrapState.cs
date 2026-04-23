using Microsoft.Xna.Framework;

public class ReturnSpiketrapState : ISpiketrapState
{
    private SpikeTile _trap;
    private float _returnSpeed = Settings.Instance.SpiketrapReturnSpeed;

    public ReturnSpiketrapState(SpikeTile trap)
    {
        _trap = trap;
    }

    public void Update(GameTime gameTime)
    {
        Vector2 directionToHome = _trap.OriginalPosition - _trap.Position;
        float distance = directionToHome.Length();

        // If we are close enough to home, snap into place to prevent jittering
        if (distance <= _returnSpeed)
        {
            _trap.Position = _trap.OriginalPosition;
            _trap.ChangeState(new IdleSpiketrapState(_trap));
        }
        else
        {
            directionToHome.Normalize();
            _trap.Position += directionToHome * _returnSpeed;
        }
    }

    public void OnWallCollision()
    {
        

    }
}
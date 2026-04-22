using Microsoft.Xna.Framework;

public class AttackSpiketrapState : ISpiketrapState
{
    private SpikeTile _trap;
    private Vector2 _direction;
    private float _attackSpeed = Settings.Instance.SpiketrapAttackSpeed;

    public AttackSpiketrapState(SpikeTile trap, Vector2 direction)
    {
        _trap = trap;
        _direction = direction;
    }

    public void Update(GameTime gameTime)
    {
        _trap.Position += _direction * _attackSpeed;
    }
    public void OnWallCollision()
    {
        _trap.ChangeState(new ReturnSpiketrapState(_trap));
    }

}
using Microsoft.Xna.Framework;

public interface ISpiketrapState
{
    void Update(GameTime gameTime);

    public void OnWallCollision();
}
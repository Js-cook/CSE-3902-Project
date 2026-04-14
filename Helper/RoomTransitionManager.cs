using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class RoomTransitionManager
{
    private GraphicsDevice graphicsDevice;
    private SpriteBatch spriteBatch;
    private RenderTarget2D oldRoomTarget;
    private RenderTarget2D newRoomTarget;

    public bool IsTransitioning { get; private set; }
    private int direction;
    private float progress;

    private const float TransitionDuration = 0.75f;
    private const int HudHeight = 224;
    private const int ScreenWidth = 1025;
    private const int ScreenHeight = 928;
    private const int GameAreaHeight = ScreenHeight - HudHeight;

    public RoomTransitionManager(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
        this.graphicsDevice = graphicsDevice;
        this.spriteBatch = spriteBatch;
        oldRoomTarget = new RenderTarget2D(graphicsDevice, ScreenWidth, ScreenHeight);
        newRoomTarget = new RenderTarget2D(graphicsDevice, ScreenWidth, ScreenHeight);
    }

    public void StartTransition(int direction, Action drawRoom, Action loadNewRoom)
    {
        if (IsTransitioning) return;

        this.direction = direction;
        this.progress = 0f;
        IsTransitioning = true;

        graphicsDevice.SetRenderTarget(oldRoomTarget);
        graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        drawRoom();
        spriteBatch.End();

        loadNewRoom();
        graphicsDevice.SetRenderTarget(newRoomTarget);
        graphicsDevice.Clear(Color.Black);
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        drawRoom();
        spriteBatch.End();

        graphicsDevice.SetRenderTarget(null);
    }

    public void Update(GameTime gameTime)
    {
        if (!IsTransitioning) return;

        progress += (float)gameTime.ElapsedGameTime.TotalSeconds / TransitionDuration;
        if (progress >= 1f)
        {
            progress = 1f;
            IsTransitioning = false;
        }
    }

    public void Draw()
    {
        if (!IsTransitioning) return;

        Rectangle sourceRect = new Rectangle(0, HudHeight, ScreenWidth, GameAreaHeight);

        Vector2 oldOffset = Vector2.Zero;
        Vector2 newOffset = Vector2.Zero;

        switch (direction)
        {
            case 0: // Top
                oldOffset = new Vector2(0, progress * GameAreaHeight);
                newOffset = new Vector2(0, -GameAreaHeight + progress * GameAreaHeight);
                break;
            case 1: // Right
                oldOffset = new Vector2(-progress * ScreenWidth, 0);
                newOffset = new Vector2(ScreenWidth - progress * ScreenWidth, 0);
                break;
            case 2: // Bottom
                oldOffset = new Vector2(0, -progress * GameAreaHeight);
                newOffset = new Vector2(0, GameAreaHeight - progress * GameAreaHeight);
                break;
            case 3: // Left
                oldOffset = new Vector2(progress * ScreenWidth, 0);
                newOffset = new Vector2(-ScreenWidth + progress * ScreenWidth, 0);
                break;
        }

        Rectangle oldDest = new Rectangle(
            (int)oldOffset.X, HudHeight + (int)oldOffset.Y,
            ScreenWidth, GameAreaHeight);
        Rectangle newDest = new Rectangle(
            (int)newOffset.X, HudHeight + (int)newOffset.Y,
            ScreenWidth, GameAreaHeight);

        spriteBatch.Draw(oldRoomTarget, oldDest, sourceRect, Color.White);
        spriteBatch.Draw(newRoomTarget, newDest, sourceRect, Color.White);
    }

    public void Reset()
    {
        IsTransitioning = false;
        progress = 0f;
    }
}

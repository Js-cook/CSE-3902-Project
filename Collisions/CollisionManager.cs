using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class CollisionManager
{
    private Dictionary<(Type, Type), ICollisionHandler> collisionHandlers;
    private List<(Rectangle hitbox, Color color)> hitboxesToDraw = new List<(Rectangle, Color)>();
    
    private bool debugMode = false;
    public bool DebugMode 
    { 
        get { return debugMode; }
        set { debugMode = value; }
    }

    // Cache the white pixel texture to avoid creating/disposing it every frame
    private Texture2D whitePixel;

    public CollisionManager()
    {
        collisionHandlers = new Dictionary<(Type, Type), ICollisionHandler>();
        whitePixel = null;
    }

    public void RegisterHandler(Type type1, Type type2, ICollisionHandler handler)
    {
        collisionHandlers[(type1, type2)] = handler;
        collisionHandlers[(type2, type1)] = handler; // Ensure symmetry
    }

    public ICollisionHandler GetCollisionHandler<T1, T2>()
    {
        collisionHandlers.TryGetValue((typeof(T1), typeof(T2)), out ICollisionHandler handler);
        return handler;
    }

    public ICollisionHandler GetCollisionHandler(Type type1, Type type2)
    {
        collisionHandlers.TryGetValue((type1, type2), out ICollisionHandler handler);
        return handler;
    }

    public void Update(GameTime gameTime, List<ICollidable> collidables)
    {
        hitboxesToDraw.Clear();

        for (int i = 0; i < collidables.Count; i++)
        {
            for (int j = i + 1; j < collidables.Count; j++)
            {
                ICollidable obj1 = collidables[i];
                ICollidable obj2 = collidables[j];
                
                if (obj1.HitboxActive && obj2.HitboxActive)
                {
                    if (obj1.Hitbox.Intersects(obj2.Hitbox))
                    {
                        Rectangle intersection = Rectangle.Intersect(obj1.Hitbox, obj2.Hitbox);

                        Type type = obj1.GetType();
                        Type type2 = obj2.GetType();

                        ICollisionHandler handler = GetCollisionHandler(type, type2);
                        if (handler != null)
                        {
                            handler.HandleCollision(obj1, obj2, intersection);
                        }

                        // Debug: Store intersection for visualization
                        if (debugMode)
                        {
                            hitboxesToDraw.Add((intersection, Color.Red));
                        }
                    }
                }

                // Debug: Always draw active hitboxes
                if (debugMode && obj1.HitboxActive)
                {
                    hitboxesToDraw.Add((obj1.Hitbox, GetColorForType(obj1.GetType())));
                }
                if (debugMode && obj2.HitboxActive)
                {
                    hitboxesToDraw.Add((obj2.Hitbox, GetColorForType(obj2.GetType())));
                }
            }
        }
    }

    /// <summary>
    /// Initializes the white pixel texture (call this from LoadContent in PlayingState)
    /// </summary>
    public void Initialize(GraphicsDevice graphicsDevice)
    {
        if (whitePixel == null)
        {
            whitePixel = new Texture2D(graphicsDevice, 1, 1);
            whitePixel.SetData(new[] { Color.White });
        }
    }

    /// <summary>
    /// Draws all hitboxes to the screen (only works in debug mode)
    /// </summary>
    public void DrawHitboxes(SpriteBatch spriteBatch)
    {
        if (!debugMode || hitboxesToDraw.Count == 0 || whitePixel == null)
            return;

        foreach (var (hitbox, color) in hitboxesToDraw)
        {
            // Draw outline
            DrawRectangleOutline(spriteBatch, hitbox, color, 5);
        }
    }

    /// <summary>
    /// Draws a rectangle outline using the cached white pixel texture
    /// </summary>
    private void DrawRectangleOutline(SpriteBatch spriteBatch, Rectangle rect, Color color, int thickness)
    {
        // Top line
        spriteBatch.Draw(whitePixel, new Rectangle(rect.X, rect.Y, rect.Width, thickness), color);
        // Bottom line
        spriteBatch.Draw(whitePixel, new Rectangle(rect.X, rect.Y + rect.Height - thickness, rect.Width, thickness), color);
        // Left line
        spriteBatch.Draw(whitePixel, new Rectangle(rect.X, rect.Y, thickness, rect.Height), color);
        // Right line
        spriteBatch.Draw(whitePixel, new Rectangle(rect.X + rect.Width - thickness, rect.Y, thickness, rect.Height), color);
    }

    /// <summary>
    /// Returns a color based on the type of collidable object
    /// </summary>
    private Color GetColorForType(Type type)
    {
        if (typeof(Link).IsAssignableFrom(type))
            return Color.Blue;
        if (typeof(IEnemy).IsAssignableFrom(type))
            return Color.Yellow;
        if (typeof(IProjectile).IsAssignableFrom(type))
            return Color.Green;
        if (typeof(Tile).IsAssignableFrom(type))
            return Color.Gray;
        if (typeof(SpikeTile).IsAssignableFrom(type))
            return Color.Purple;
        if (typeof(PickupItem).IsAssignableFrom(type))
            return Color.Cyan;
        if (typeof(TreasureChest).IsAssignableFrom(type))
            return Color.Orange;
        if (typeof(Doorway).IsAssignableFrom(type))
            return Color.Lime;

        return Color.White;
    }
}
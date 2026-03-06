using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class CollisionManager
{
    private Dictionary<(Type, Type), ICollisionHandler> collisionHandlers;
    private List<ICollidable> collidables;
    private Texture2D hitboxTexture; 
    public CollisionManager(GraphicsDevice graphicsDevice)
    {
        collisionHandlers = new Dictionary<(Type, Type), ICollisionHandler>();
        hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
        hitboxTexture.SetData(new[] { Color.White }); // Fill that 1 pixel with White

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
        this.collidables = collidables;
        for (int i = 0; i < collidables.Count; i++)
        {
            for (int j = i + 1; j < collidables.Count; j++)
            {
                ICollidable obj1 = collidables[i];
                ICollidable obj2 = collidables[j];
               
                if (obj1.HitboxActive && obj2.HitboxActive)
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
                }
                
            }
        }
    }

    public void Draw(SpriteBatch sb)
    {
        // Debug: Draw hitboxes in the collidable array
        foreach (ICollidable collidable in collidables)
        {
            sb.Draw(hitboxTexture, collidable.Hitbox, Color.Red * 0.5f);
        }

    }


}
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class CollisionManager
{
    private Dictionary<(Type, Type), ICollisionHandler> collisionHandlers;
    public CollisionManager()
    {
        collisionHandlers = new Dictionary<(Type, Type), ICollisionHandler>();
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
        for (int i = 0; i < collidables.Count; i++)
        {
            for (int j = i + 1; j < collidables.Count; j++)
            {
                ICollidable obj1 = collidables[i];
                ICollidable obj2 = collidables[j];

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


}
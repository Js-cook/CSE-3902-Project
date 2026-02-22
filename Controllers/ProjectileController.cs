using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Controllers
{
    public class ProjectileController
    {
        public List<IProjectile> projectiles { get; set; } = new List<IProjectile>();
        private ProjectileSpriteFactory projectileSpriteFactory;

        public ProjectileController(ProjectileSpriteFactory projectileSpriteFactory)
        {
            this.projectileSpriteFactory = projectileSpriteFactory;
        }

        public void Update(GameTime gametime)
        {
            List<IProjectile> markedForDeletion = new List<IProjectile>();

            foreach (IProjectile projectile in projectiles)
            {
                if (!projectile.Active)
                {
                    markedForDeletion.Add(projectile);

                }
                projectile.Update(gametime);
            }

            foreach (IProjectile projectile in markedForDeletion)
            {
                projectiles.Remove(projectile);
                if (projectile is Arrow || projectile is SilverArrow)
                {
                    projectiles.Add(new ArrowParticle(projectile.Position, projectileSpriteFactory));
                }
                if (projectile is Bomb)
                {
                    projectiles.Add(new BombParticle(projectile.Position, projectileSpriteFactory));
                }
            }
        }

        public void Draw()
        {
            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw();
            }
        }
    }
}

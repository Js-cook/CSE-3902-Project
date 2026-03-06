using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace Controllers
{
    public class ProjectileController
    {
        public List<IProjectile> projectiles { get; set; } = new List<IProjectile>();
        private ProjectileSpriteFactory projectileSpriteFactory;
        private Dictionary<string, SoundEffect> soundEffect;
        private AudioController audioController = new();

        public ProjectileController(ProjectileSpriteFactory projectileSpriteFactory, Dictionary<string, SoundEffect> soundEffect)
        {
            this.projectileSpriteFactory = projectileSpriteFactory;
            this.soundEffect = soundEffect;
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
                    audioController.PlaySoundEffect(soundEffect["BombExplode"], 0.75f);
                    //projectiles.Add(new BombParticle(projectile.Position, projectileSpriteFactory));
                    projectiles.Add(new BombParticle(new Vector2(projectile.Position.X + 5, projectile.Position.Y + 5), projectileSpriteFactory));
                    projectiles.Add(new BombParticle(new Vector2(projectile.Position.X - 5, projectile.Position.Y + 5), projectileSpriteFactory));
                    projectiles.Add(new BombParticle(new Vector2(projectile.Position.X + 5, projectile.Position.Y - 5), projectileSpriteFactory));
                    projectiles.Add(new BombParticle(new Vector2(projectile.Position.X - 5, projectile.Position.Y - 5), projectileSpriteFactory));
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

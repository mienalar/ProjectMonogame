using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01.Armory
{
    public class BulletsManager
    {
        protected List<Bullet> bullets;
        protected List<Bullet> bulletsToRemove;

        public BulletsManager()
        {
            bullets = new List<Bullet>();
            bulletsToRemove = new List<Bullet>();
        }

        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
            bullet.Finish += BulletFinish;
        }

        private void BulletFinish(GameObject obj)
        {
            bulletsToRemove.Add( (Bullet)obj );
        }

        public void Update(GameTime gameTime)
        {
            foreach (var b in bullets)
            {
                b.Update(gameTime);
            }
            // удаляем отработанные пули
            foreach (var b in bulletsToRemove)
            {
                bullets.Remove(b);
            }
            bulletsToRemove.Clear();
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (var b in bullets)
            {
                b.Draw(batch);
            }
        }
    }
}

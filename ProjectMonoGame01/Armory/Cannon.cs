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
    public class Cannon
    {
        protected GameObject owner;
        protected Texture2D texBullet;

        private float _power;
        public float Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public Cannon(GameObject owner)
        {
            _power = 10;
            this.owner = owner;

            texBullet = new Texture2D(GlobalsItems.Graphics.GraphicsDevice,1,1);
            texBullet.SetData<Color>(new Color[] { Color.White });
        }

        public void Fire()
        {
            Bullet bullet = new Bullet(texBullet, owner);
            bullet.Position = owner.Position;

            float vx = (float)(_power * Math.Cos(owner.Angle));
            float vy = (float)(_power * Math.Sin(owner.Angle));

            bullet.SetVelocity(vx, vy);
            bullet.SetScale(4);

            GlobalsItems.BulletsManager.AddBullet(bullet);
        }
    }
}

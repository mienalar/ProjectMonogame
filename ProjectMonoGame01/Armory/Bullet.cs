using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.DelegatesEvents;
using ProjectMonoGame01.Units;

namespace ProjectMonoGame01.Armory
{
    public class Bullet : GameUnit
    {
        public event GameObjectEvent Finish;

        protected long allottedTime;
        protected GameObject owner;

        public Bullet(Texture2D texture, GameObject owner) 
            : base(texture)
        {
            allottedTime = 10000;
            this.owner = owner;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (_lifeTime >= allottedTime)
            {
                // нужно удалить!
                Finish?.Invoke(this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01.Controllers
{
    public class MouseControllerPursuit
        : MouseControllerWatch
    {
        protected bool isPursuit = false;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (ms.RightButton == ButtonState.Pressed)
            {
                isPursuit = true;   
            }
            if (isPursuit)
            {
                Vector2 velocity = target / 20;
                slave.SetVelocity(velocity.X, velocity.Y);

                if (target.Length() < 50)
                {
                    isPursuit = false;
                    slave.SetVelocity(0,0);
                }
            }
        }
    }
}

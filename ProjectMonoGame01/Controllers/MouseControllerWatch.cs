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
    public class MouseControllerWatch :
        MouseControllerBase
    {
        protected Vector2 target;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (slave == null) return;
            Vector2 v1 = slave.Position;
            Vector2 v2 = new Vector2(ms.X, ms.Y);
            Vector2 v3 = v2 - v1;
            target = v3;

            double alpha = Math.Atan2(v3.Y, v3.X);
            slave.Angle = (float) alpha; 
        }
    }
}

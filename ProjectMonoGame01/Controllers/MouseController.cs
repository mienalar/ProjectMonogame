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
    public class MouseController 
        : MouseControllerBase
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (slave == null) return;
            slave.SetPosition(ms.X, ms.Y);
        }
    }
}

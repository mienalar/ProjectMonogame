using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.DelegatesEvents;

namespace ProjectMonoGame01.Controllers
{
    public class MouseControllerBase 
        : ControllerBase
    {
        public event MouseEvent MouseMove;
        public event MouseEvent LeftButtonDown;
        public event MouseEvent LeftButtonClick;

        protected MouseState ms;
        protected MouseState prevMs;

        public override void Update(GameTime gameTime)
        {
            ms = Mouse.GetState();
            Vector2 pos = new Vector2(ms.X, ms.Y);

            if (ms.X != prevMs.X || 
                ms.Y != prevMs.Y)
            {
                MouseMove?.Invoke(pos);
            }

            if (ms.LeftButton == ButtonState.Pressed)
            {
                LeftButtonDown?.Invoke(pos);
            }
            if (ms.LeftButton == ButtonState.Released &&
                prevMs.LeftButton == ButtonState.Pressed)
            {
                LeftButtonClick?.Invoke(pos);
            }
            base.Update(gameTime);
            prevMs = ms;
        }
    }
}

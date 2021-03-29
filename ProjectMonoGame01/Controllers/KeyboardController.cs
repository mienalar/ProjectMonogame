using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.KeyboardLayouts;

namespace ProjectMonoGame01.Controllers
{
    public class KeyboardController : ControllerBase
    {
        protected KeyboardLayout layout;

        public void ChangeKeyboardLayout(KeyboardLayout layout)
        {
            this.layout = layout;
        }

        public KeyboardController()
        {
            layout = new KeyboardLayoutArrows();
        }

        public KeyboardController(KeyboardLayout layout)
        {
            this.layout = layout;
        }

        public override void Update(GameTime gameTime)
        {
            if (slave == null) return;

            float speed = 2.5f;
            Vector2 delta = new Vector2(0, 0);
            // управление с клавиатуры
            KeyboardState ks = Keyboard.GetState();
            foreach (var item in layout.KeyActions)
            {
                if (ks.IsKeyDown(item.Key))
                {
                    switch (item.Direction)
                    {
                        case ActionType.Left:
                            delta.X = -speed;
                            break;
                        case ActionType.Right:
                            delta.X = +speed;
                            break;
                        case ActionType.Up:
                            delta.Y = -speed;
                            break;
                        case ActionType.Down:
                            delta.Y = +speed;
                            break;
                    }
                }
            }
            slave.Move(delta);
            slave.Update(gameTime);
        }
    }
}

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
    public class KeyboardControllerRotate : 
        KeyboardController
    {
        public KeyboardControllerRotate()
        {
        }

        public KeyboardControllerRotate(KeyboardLayout layout) : base(layout)
        {
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
                            slave.Rotate(-1);
                            break;
                        case ActionType.Right:
                            slave.Rotate(+1);
                            break;
                        case ActionType.Up:
                            delta.X = (float) (+speed * Math.Cos(slave.Angle));
                            delta.Y = (float) (+speed * Math.Sin(slave.Angle));
                            break;
                        case ActionType.Down:
                            delta.X = (float) (-speed * Math.Cos(slave.Angle));
                            delta.Y = (float) (-speed * Math.Sin(slave.Angle));
                            break;
                    }
                }
            }
            slave.Move(delta);
            // slave.Update(gameTime);
        }
    }
}

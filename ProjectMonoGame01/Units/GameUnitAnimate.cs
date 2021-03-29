using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ProjectMonoGame01.Units
{
    public class GameUnitAnimate : GameUnit
    {
        protected int msInterval;
        protected int msCounter;

        protected int frameWidth;
        protected int frameHeight;
        protected Rectangle frameRectangle;
        protected int rows, cols;
        protected int quantity;
        protected int currentFrame;

        public int FrameInterval
        {
            get { return msInterval; }
            set { msInterval = value; }
        }

        public GameUnitAnimate(Texture2D texture, int rows, int cols, int quantity = -1) 
            : base(texture)
        {
            msInterval = 70;
            msCounter = 0;

            frameWidth = texture.Width / cols;
            frameHeight = texture.Height / rows;
            frameRectangle = new Rectangle(0, 0, frameWidth, frameHeight);
            this.rows = rows;
            this.cols = cols;

            if (quantity == -1)
            {
                this.quantity = rows * cols;
            }
            else
            {
                this.quantity = quantity;
            }

            origin = new Vector2(frameWidth/2, frameHeight/2);
            boundingBox.Width = frameWidth;
            boundingBox.Height = frameHeight;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            msCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (msCounter >= msInterval)
            {
                msCounter = 0;
                // переключаем на след кадр
                currentFrame++;
                // анимацию зациклили
                if (currentFrame == quantity)
                    currentFrame = 0;
                // находим положение кадра на листе
                int row = currentFrame / cols;
                int col = currentFrame % cols;
                // вычислить X, Y
                int x = col * frameWidth;
                int y = row * frameHeight;
                // смещаем прямоугольник для вырезания
                frameRectangle.X = x;
                frameRectangle.Y = y;
            } 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, // картинка
                position, // координаты
                frameRectangle, // прямоугольник - вырезание из картиника
                Color.White, // цвет смешивания
                angle, // угол поворота
                origin, // точка поворота
                scale, // коэф масшт
                SpriteEffects.None, // эффекты
                1 // слой
                );
        }
    }
}

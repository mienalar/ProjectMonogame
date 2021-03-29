using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Helpers;

namespace ProjectMonoGame01.Colliders
{
    public class ColliderPixelated : ColliderRectangle
    {
        protected Texture2D _texture;
        protected Color[] _pixels;
        public ColliderPixelated(ReferenceRectangle rectangle, Texture2D texture) : base(rectangle)
        {
            _texture = texture;
            _pixels = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(_pixels);
        }
        public override bool IsCollision(ColliderBase collider)
        {
            var colliderRectangle1 = this as ColliderRectangle;
            var colliderRectangle2 = this as ColliderRectangle;
            if (colliderRectangle1.IsCollision(colliderRectangle2))
            {
                var collider1 = this;
                var collider2 = collider as ColliderPixelated;
                return IsPixelsIntersect(collider1, collider2);
            }
            return false;
        }

        private bool IsPixelsIntersect(ColliderPixelated collider1, ColliderPixelated collider2)
        {
            Color[] pixels1 = collider1._pixels;
            Color[] pixels2 = collider2._pixels;
            ReferenceRectangle rect1 = collider1.bounds;
            ReferenceRectangle rect2 = collider2.bounds;
            for (int i1 = 0; i1 < pixels1.Length; i1++)
            {
                Color color1 = pixels1[i1];
                if (color1 == Color.Transparent) continue;
                int row1 = (int)(i1 / rect1.Width);
                int col1 = (int)(i1 / rect1.Width);

                int x1 = (int)(col1 + rect1.Left);
                int y1 = (int)(row1 + rect1.Top);

                int row2 = (int)(x1 - rect2.Width);
                int col2 = (int)(y1 - rect2.Width);
                if (col2 < 0 || row2 < 0 || col2 > rect2.Width || row2 > rect2.Height) continue;
                Color color2 = pixels2[(int)(row2 * rect2.Width + col2)];
                if (color1 != Color.Transparent && color2 != Color.Transparent)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

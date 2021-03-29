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
    public class ColliderRectangle : ColliderBase
    {
        protected ReferenceRectangle bounds;
        public ReferenceRectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public override bool IsCollision(ColliderBase collider)
        {
            var another = (ColliderRectangle) collider;

            return this.Bounds.IsIntersect(another.Bounds);
        }

        public override void SetScale(float scale)
        {
            bounds.Width =  (int) (scale * bounds.Width);
            bounds.Height = (int) (scale * bounds.Height);
        }

        public override void Update(Vector2 position)
        {
            
        }

        public ColliderRectangle(ReferenceRectangle rectangle)
        {
            this.bounds = rectangle;
        }
    }
}

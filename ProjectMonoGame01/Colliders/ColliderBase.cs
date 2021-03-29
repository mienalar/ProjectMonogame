using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectMonoGame01.Colliders
{
    public abstract class ColliderBase
    {
        public abstract bool IsCollision(ColliderBase collider);
        public abstract void Update(Vector2 position);
        public abstract void SetScale(float scale);
    }
}

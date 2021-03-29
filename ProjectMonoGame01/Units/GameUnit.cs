using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Colliders;

namespace ProjectMonoGame01.Units
{
    public class GameUnit : GameObject
    {
        protected ColliderBase _collider;
        public ColliderBase Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        /// <summary>
        /// Откат положения объекта к
        /// предыдущей позиции
        /// </summary>
        public Vector2 Rollback()
        {
            Vector2 delta = previousPosition - position;
            Move(delta);
            isPositionChanges = false;
            return delta;
        }

        public void Rollback(Vector2 delta)
        {
            Move(delta);
        }

        public GameUnit(Texture2D texture) : base(texture)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Location = new Point(0,0);
            rectangle.Width = texture.Width;
            rectangle.Height = texture.Height;         
        }

        public void BindCollider(ColliderBase collider)
        {
            _collider = collider;
            //_collider.SetScale(this.Scale);
        }

        public override void SetScale(float scale)
        {
            base.SetScale(scale);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}

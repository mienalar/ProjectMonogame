using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Armory;

namespace ProjectMonoGame01.Units
{
    public class GameUnitShooter
        : GameUnit
    {
        protected Cannon cannon;

        public float CannonPower
        {
            get { return cannon.Power; }
            set { cannon.Power = value; }
        }

        public void Shoot(Vector2 pos)
        {
            cannon.Fire();
        }

        public GameUnitShooter(Texture2D texture) 
            : base(texture)
        {
            cannon = new Cannon(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Colliders;
using ProjectMonoGame01.Controllers;
using ProjectMonoGame01.Geometry;
using ProjectMonoGame01.Units;

namespace ProjectMonoGame01.Engine
{
    public class GameEngine 
        : DrawableGameComponent
    {
        protected GeometryManager geometry;

        protected SpriteBatch spriteBatch;
        protected List<ControllerBase> controllers;
        protected List<GameObject> gameObjects;

        // список юнитов, для которых проверка столкновений
        protected List<GameUnit> units;

        public GameEngine(Game game) : base(game)
        {
            geometry = new GeometryManager(game);

            GlobalsItems.BulletsManager = new Armory.BulletsManager();
            game.Components.Add(this);
            controllers = new List<ControllerBase>();
            gameObjects = new List<GameObject>();
            units = new List<GameUnit>();
        }

        private void CheckColissions()
        {
            // проверяем столкновение каждый с каждый
            for (int i = 0; i < units.Count-1; i++)
            {
                GameUnit unitI = units[i];
                ColliderBase colliderI = unitI.Collider;

                if (unitI.HasChanges)
                {
                    for (int j = 0; j < units.Count; j++)
                    {
                        if (j == i) continue;
                        GameUnit unitJ = units[j];
                        ColliderBase colliderJ = unitJ.Collider;
                        if (colliderI.IsCollision(colliderJ))
                        {
                            // столкновение!
                            Vector2 delta = unitI.Rollback();
                            break;
                        }
                    }
                }
            }
        }

        private void Add(GameObject obj)
        {
            var fig = new GeometryBoundingBox(obj);
            geometry.AddFigure(fig);

            if (obj is GameUnit)
            {
                GameUnit unit = obj as GameUnit;
                units.Add(unit);
                unit.BindCollider(new ColliderPixelated(fig.RefRect));
            }
            gameObjects.Add(obj);
        }

        public void AddObject(GameObject obj)
        {
            Add(obj);
        }

        public void AddObject(GameObject obj, ControllerBase controller)
        {
            Add(obj);
            controllers.Add(controller);
            controller.Attach(obj);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            CheckColissions();
            base.Update(gameTime);

            GlobalsItems.BulletsManager.Update(gameTime);
            foreach (var obj in gameObjects)
            {
                obj.Update(gameTime);
            }
            foreach (var c in controllers)
            {
                c.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();
            foreach (var obj in gameObjects)
            {
                obj.Draw(spriteBatch);
            }
            GlobalsItems.BulletsManager.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}

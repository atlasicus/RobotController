using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RobotController.Renderer.Implementation;
using RobotController.Robots.Implementaiton;
using RobotController.Robots.Interface;

namespace RobotController.Control.Implementation
{
    public class AcceptanceRoboManager : Interface.UpdatableActor
    {
        Actor robotActor;
        DrawableActor robotDrawable;

        Vector2 actorCoords;
        float actorAngle;

        protected int tileSize;

        public AcceptanceRoboManager(Texture2D texture, Rectangle position, int tileSize = 32)
        {
            robotDrawable = new DrawableActor(texture, position);
            robotActor = new AcceptanceRobo(new Vector2(position.X, position.Y));

            actorCoords = new Vector2(position.X, position.Y);

            this.tileSize = tileSize;
        }

        public void UpdatePosition(Vector2 position)
        {
            robotActor.SetCoordinates(position);
            robotDrawable.SetCoordinates(position * tileSize);
            actorCoords = position;
        }

        public void UpdateRotation(float angle)
        {
            robotActor.SetAngle(angle);
            robotDrawable.SetAngle(angle);
            actorAngle = angle;
        }

        public int getTileSize()
        {
            return tileSize;
        }

        public void setTileSize(int tileSize)
        {
            this.tileSize = tileSize;
        }

        public Vector2 GetPosition()
        {
            return actorCoords;
        }

        public float GetRotation()
        {
            return actorAngle;
        }

        public Actor GetActor()
        {
            return robotActor;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            robotDrawable.draw(spriteBatch);
        }
    }
}

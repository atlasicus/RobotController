using System;
using Microsoft.Xna.Framework;

namespace RobotController.Robots.Implementaiton
{
    class AcceptanceRobo : Interface.Actor
    {
        Vector2 coordinates;
        float angle;

        public AcceptanceRobo(Vector2 coordinates, float angle)
        {
            this.coordinates = coordinates;
            this.angle = angle;
        }

        public AcceptanceRobo(Vector2 coordinates)
        {
            this.coordinates = coordinates;
            this.angle = 0f;
        }

        public AcceptanceRobo(int x, int y, float rotation)
        {
            this.coordinates = new Vector2((float)x, (float)y);
            this.angle = rotation;
        }

        public AcceptanceRobo(int x, int y)
        {
            this.coordinates = new Vector2((float)x, (float)y);
            this.angle = 0f;
        }

        public Vector2 GetCoordinates()
        {
            return this.coordinates;
        }

        public float GetAngle()
        {
            return this.angle;
        }

        public void SetCoordinates(Vector2 position)
        {
            coordinates = position;
        }

        public void SetAngle(float angle)
        {
            this.angle = angle;
        }
    }
}

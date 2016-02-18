using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RobotController.Robots.Interface;

namespace RobotController.Renderer.Implementation
{
    class DrawableActor : RotatableSprite, Actor
    {
        Vector2 coordinates;

        public DrawableActor(Texture2D texture, Rectangle position)
            : base(texture, position)
        {
            coordinates = new Vector2(position.X, position.Y);
            this.angle = 0f;
        }

        public DrawableActor(Texture2D texture, Rectangle position, float angle)
            :base(texture, position, angle)
        {
            coordinates = new Vector2(position.X, position.Y);
            this.angle = angle;
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
            base.setPosition((int)position.X, (int)position.Y);
        }

        public void SetAngle(float angle)
        {
            this.angle = angle;
        }
    }
}

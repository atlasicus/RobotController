using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RobotController.Robots.Interface;

namespace RobotController.Control.Interface
{
    public interface UpdatableActor
    {
        void UpdatePosition(Vector2 position);
        void UpdateRotation(float angle);

        Vector2 GetPosition();
        float GetRotation();

        void setTileSize(int tileSize);
        int getTileSize();

        Actor GetActor();

        void draw(SpriteBatch spriteBatch);
    }
}

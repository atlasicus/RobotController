using Microsoft.Xna.Framework;

namespace RobotController.Robots.Interface
{
    public interface Actor
    {
        Vector2 GetCoordinates();
        void SetCoordinates(Vector2 position);
        float GetAngle();
        void SetAngle(float angle);
    }
}

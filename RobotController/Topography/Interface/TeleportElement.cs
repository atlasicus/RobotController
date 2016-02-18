using Microsoft.Xna.Framework;

namespace RobotController.Topography.Interface
{
    public interface TeleportElement
    {
        Vector2 GetDestination();
        void SetDestination(int x, int y);
    }
}

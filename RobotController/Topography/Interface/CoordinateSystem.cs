using Microsoft.Xna.Framework;

namespace RobotController.Topography.Interface
{
    public interface CoordinateSystem
    {
        void IntializeMap();

        InteractionElement[,] GetMap();
        InteractionElement GetElement(int x, int y);

        Vector2 GetTeleporterDestination(int x, int y);

        void SetElement(InteractionElement element, int x, int y);
        int GetSizeX();
        int GetSizeY();
    }
}

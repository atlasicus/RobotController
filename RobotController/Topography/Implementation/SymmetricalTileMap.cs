using Microsoft.Xna.Framework;
using RobotController.Topography.Interface;

namespace RobotController.Topography.Implementation
{
    public class SymmetricalTileMap : Interface.CoordinateSystem
    {
        int size;
        TeleportTile[,] map;

        public SymmetricalTileMap(int size)
        {
            this.size = size;
            map = new TeleportTile[size, size];
        }

        public void IntializeMap()
        {
            for(int yCoord = 0; yCoord < size; ++yCoord)
            {
                for (int xCoord = 0; xCoord < size; ++xCoord)
                {
                    map[xCoord, yCoord] = new TeleportTile(0);
                }
            }
        }

        public InteractionElement GetElement(int x, int y)
        {
            return map[x, y];
        }

        public void SetElement(InteractionElement element , int x, int y)
        {
            map[x, y] = element as TeleportTile;
        }

        public InteractionElement[,] GetMap()
        {
            return map;
        }

        public int GetSizeX()
        {
            return size;
        }

        public int GetSizeY()
        {
            return size;
        }

        public Vector2 GetTeleporterDestination(int x, int y)
        {
            return map[x, y].GetDestination();
        }
    }
}

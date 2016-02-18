using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RobotController.Topography.Interface;

namespace RobotControllerTest.Mocks.Topography
{
    //Mocks a Symmetrical Tile Map
    class MockCoordinateSystem : RobotController.Topography.Interface.CoordinateSystem
    {
        int size;
        InteractionElement[,] map;
        
        public MockCoordinateSystem(int size)
        {
            this.size = size;
            this.map = new MockInteractionElement[size, size];
        }

        public void IntializeMap()
        {
            for (int yCoord = 0; yCoord < size; ++yCoord)
            {
                for (int xCoord = 0; xCoord < size; ++xCoord)
                {
                    map[xCoord, yCoord] = new MockInteractionElement(0);
                }
            }
        }

        public InteractionElement GetElement(int x, int y)
        {
            return map[x, y];
        }

        public void SetElement(InteractionElement element, int x, int y)
        {
            map[x, y] = element;
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
            return (map[x, y] as MockInteractionElement).GetDestination();
        }
    }
}

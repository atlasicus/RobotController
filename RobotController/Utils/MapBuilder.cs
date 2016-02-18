using System;
using Microsoft.Xna.Framework;
using RobotController.Navigation.Implementation;
using RobotController.Topography.Implementation;

namespace RobotController.Utils
{
    static class MapBuilder
    {
        public static SymmetricalTileMap BuildSymmetrical(byte[,] inputMap, AcceptanceTTManager traversalManager)
        {
            SymmetricalTileMap outputMap = new SymmetricalTileMap(inputMap.GetLength(0));
            outputMap.IntializeMap();

            Random random = new Random();

            for(int i = 0; i < inputMap.GetLength(0); ++i)
            {
                for(int j = 0; j < inputMap.GetLength(1); ++j)
                {
                    TeleportTile tileElement = new TeleportTile(inputMap[j,i]);

                    //Hardcoded due to time constraints
                    if (tileElement.GetInteractionValue() == 2)
                    {
                        int destX = random.Next(0, inputMap.GetLength(0));
                        int destY = random.Next(0, inputMap.GetLength(1));

                        tileElement.SetDestination(destX, destY);

                        TeleportList.SetTeleportLocation(j, i, destX, destY);
                    }

                    outputMap.SetElement(tileElement, j, i);

                }
            }

            return outputMap;
        }
    }
}

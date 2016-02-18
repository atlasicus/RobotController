using RobotController.Topography.Interface;

namespace RobotController.Topography.Implementation
{
    //Short for Linear Symmetrical Tile Map Generator
    class LinearSTMGenerator : Interface.TopographyGenerator
    {
        public void CreateNewTopography(ref CoordinateSystem coordinateSystem, byte maxInteractionValue)
        {
            byte currentAssociationValue = 0;

            coordinateSystem.IntializeMap();
            for (int yCoord = 0; yCoord < coordinateSystem.GetSizeY(); ++yCoord)
            {
                for(int xCoord = 0; xCoord < coordinateSystem.GetSizeX(); ++xCoord)
                {
                    coordinateSystem.SetElement(new Tile(currentAssociationValue), xCoord, yCoord);

                    currentAssociationValue = (byte)((currentAssociationValue >= maxInteractionValue) ? 0 : currentAssociationValue + 1);
                }
            }
        }
    }
}

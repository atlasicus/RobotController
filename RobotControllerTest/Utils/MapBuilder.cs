using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotControllerTest.Mocks.Navigation;
using RobotControllerTest.Mocks.Topography;

namespace RobotControllerTest.Utils
{
    static class MapBuilder
    {
        public static MockCoordinateSystem BuildSymmetrical(byte[,] inputMap, MockRuleSet traversalManager)
        {
            MockCoordinateSystem outputMap = new MockCoordinateSystem(inputMap.GetLength(0));
            outputMap.IntializeMap();

            for (int i = 0; i < inputMap.GetLength(0); ++i)
            {
                for (int j = 0; j < inputMap.GetLength(1); ++j)
                {
                    MockInteractionElement tileElement = new MockInteractionElement(inputMap[j, i]);

                    outputMap.SetElement(tileElement, j, i);

                }
            }

            return outputMap;
        }
    }
}

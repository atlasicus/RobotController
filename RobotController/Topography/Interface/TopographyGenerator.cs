using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotController.Renderer.Interface;

namespace RobotController.Topography.Interface
{
    interface TopographyGenerator
    {
        void CreateNewTopography(ref CoordinateSystem coordinateSystem, byte maxInteractionValue);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController.Renderer.Interface
{
    interface RotatableTexture2DElement : Texture2DElement
    {
        void SetRotation(float angle);
    }
}

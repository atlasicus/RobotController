using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController.Topography.Interface
{
    public interface TeleportInteractionElement : InteractionElement, TeleportElement, 
                       IEquatable<TeleportInteractionElement>, IEqualityComparer<TeleportInteractionElement>
    {
    }
}

using System;
using System.Collections.Generic;

namespace RobotController.Topography.Interface
{
    public interface InteractionElement : IEquatable<InteractionElement>, IEqualityComparer<InteractionElement>
    {
        byte GetInteractionValue();
    }
}

using System;
using System.Collections.Generic;

namespace RobotController.Navigation.Interface
{
    public interface Rule : IEqualityComparer<Rule>
    {
        string GetInteractionValue();
        void SetInteractionValue(string action);
    }
}

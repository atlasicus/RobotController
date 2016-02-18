using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotController.Navigation.Interface;

namespace RobotControllerTest.Mocks.Navigation
{
    class MockRule : RobotController.Navigation.Interface.Rule
    {
        string interaction;

        public MockRule(string interaction)
        {
            this.interaction = interaction;
        }

        public bool Equals(Rule other)
        {
            return GetInteractionValue() == other.GetInteractionValue();
        }

        public bool Equals(Rule x, Rule y)
        {
            return x.GetInteractionValue().Equals(y.GetInteractionValue());
        }

        public int GetHashCode(Rule obj)
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash
                hash = hash * 7715177 ^ GetInteractionValue().GetHashCode();

                return hash;
            }
        }

        public string GetInteractionValue()
        {
            return interaction;
        }

        public void SetInteractionValue(string action)
        {
            interaction = action;
        }
    }
}

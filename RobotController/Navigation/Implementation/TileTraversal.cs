using System;
using RobotController.Navigation.Interface;

namespace RobotController.Navigation.Implementation
{
    class TileTraversal : Interface.Rule
    {
        string interaction;

        public TileTraversal(string interaction)
        {
            this.interaction = interaction;
        }

        public bool Equals(Rule other)
        {
            return interaction == other.GetInteractionValue();
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

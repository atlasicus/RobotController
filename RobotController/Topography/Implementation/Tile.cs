using System;
using RobotController.Topography.Interface;

namespace RobotController.Topography.Implementation
{
    class Tile : Interface.InteractionElement
    {
        byte interactionValue;

        public Tile(byte interactionValue)
        {
            this.interactionValue = interactionValue;
        }

        public override bool Equals(object obj)
        {
            return this.interactionValue == (obj as InteractionElement).GetInteractionValue();
        }

        public virtual bool Equals(InteractionElement other)
        {
            return this.interactionValue == other.GetInteractionValue();
        }

        public virtual bool Equals(InteractionElement x, InteractionElement y)
        {
            return x.GetInteractionValue() == y.GetInteractionValue();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash
                hash = hash * 7715177 ^ interactionValue.GetHashCode();

                return hash;
            }
        }

        public virtual int GetHashCode(InteractionElement obj)
        {
            return GetHashCode();
        }

        public byte GetInteractionValue()
        {
            return interactionValue;
        }
    }
}

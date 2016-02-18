using Microsoft.Xna.Framework;
using RobotController.Topography.Interface;

namespace RobotController.Topography.Implementation
{
    class TeleportTile : Tile, Interface.TeleportElement
    {
        int destinationX;
        int destinationY;

        const int noDestination = -1;

        public TeleportTile (byte interactionValue, int destinationX = noDestination, int destinationY = noDestination)
            :base(interactionValue)
        {
            this.destinationX = destinationX;
            this.destinationY = destinationY;
        }

        public void SetDestination(int x, int y)
        {
            destinationX = x;
            destinationY = y;
        }

        public Vector2 GetDestination()
        {
            return new Vector2(destinationX, destinationY);
        }

        public override bool Equals(InteractionElement other)
        {
            return base.Equals(other);
        }

        public override bool Equals(InteractionElement x, InteractionElement y)
        {
            return base.Equals(x, y);
        }

        public override int GetHashCode(InteractionElement obj)
        {
            return base.GetHashCode(obj);
        }

        public override bool Equals(object obj)
        {
            return GetInteractionValue() == (obj as InteractionElement).GetInteractionValue();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash    different 7 digit prime
                hash = hash * 7715177 ^ GetInteractionValue().GetHashCode();

                return hash;
            }
        }
    }
}

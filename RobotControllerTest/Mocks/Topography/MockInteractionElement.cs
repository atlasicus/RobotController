using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RobotController.Topography.Interface;

namespace RobotControllerTest.Mocks.Topography
{
    //Mocks a TeleportTile
    public class MockInteractionElement : RobotController.Topography.Interface.TeleportInteractionElement
    {
        byte interactionValue;

        int destinationX;
        int destinationY;

        const int noDestination = -1;

        public MockInteractionElement(byte interactionValue, int destinationX = noDestination, int destinationY = noDestination)
        {
            this.interactionValue = interactionValue;

            this.destinationX = destinationX;
            this.destinationY = destinationY;
        }

        public Vector2 GetDestination()
        {
            return new Vector2(destinationX, destinationY);
        }

        public void SetDestination(int x, int y)
        {
            destinationX = x;
            destinationY = y;
        }

        public byte GetInteractionValue()
        {
            return interactionValue;
        }

        public bool Equals(TeleportInteractionElement other)
        {
            return other.GetInteractionValue() == (interactionValue);
        }

        byte InteractionElement.GetInteractionValue()
        {
            return interactionValue;
        }

        bool IEquatable<InteractionElement>.Equals(InteractionElement other)
        {
            return other.GetInteractionValue() == interactionValue;
        }

        bool IEqualityComparer<InteractionElement>.Equals(InteractionElement x, InteractionElement y)
        {
            return x.GetInteractionValue() == y.GetInteractionValue();
        }

        int IEqualityComparer<InteractionElement>.GetHashCode(InteractionElement obj)
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash
                hash = hash * 7715177 ^ GetInteractionValue().GetHashCode();

                return hash;
            }
        }

        Vector2 TeleportElement.GetDestination()
        {
            return new Vector2(destinationX, destinationY);
        }

        void TeleportElement.SetDestination(int x, int y)
        {
            destinationX = x;
            destinationY = y;
        }

        bool IEquatable<TeleportInteractionElement>.Equals(TeleportInteractionElement other)
        {
            return other.GetInteractionValue() == interactionValue;
        }

        bool IEqualityComparer<TeleportInteractionElement>.Equals(TeleportInteractionElement x, TeleportInteractionElement y)
        {
            return x.GetInteractionValue() == y.GetInteractionValue();
        }

        int IEqualityComparer<TeleportInteractionElement>.GetHashCode(TeleportInteractionElement obj)
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash
                hash = hash * 7715177 ^ GetInteractionValue().GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object other)
        {
            return Equals(other as TeleportElement);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 1203793; //7 digit prime 

                //XOR hash
                hash = hash * 7715177 ^ GetInteractionValue().GetHashCode();

                return hash;
            }
        }
    }
}

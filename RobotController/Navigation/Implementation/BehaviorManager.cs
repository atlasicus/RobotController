using Microsoft.Xna.Framework;
using RobotController.Control.Interface;

namespace RobotController.Navigation.Implementation
{
    public abstract class BehaviorManager : Interface.Behavior
    {
        protected UpdatableActor actor;

        protected int tileSize;

        public BehaviorManager(UpdatableActor actor)
        {
            this.actor = actor;
        }

        public virtual void MoveNorth(){}

        public virtual void MoveSouth(){}

        public virtual void MoveWest() {}

        public virtual void MoveEast() {}

        public virtual void Rotate()
        {
            float currentRotation = actor.GetRotation();
            currentRotation += MathHelper.PiOver2;
            if (currentRotation >= MathHelper.Pi * 2)
                currentRotation = 0f;

            actor.UpdateRotation(currentRotation);
        }
    }
}

using System;
using Microsoft.Xna.Framework;
using RobotController.Control.Interface;
using RobotController.Navigation.Interface;
using RobotController.Topography.Interface;

namespace RobotController.Navigation.Implementation
{
    public class AcceptanceNavigationManager : BehaviorManager
    {
        RuleSet traversalRules;
        CoordinateSystem tileMap;

        public AcceptanceNavigationManager(UpdatableActor actor, RuleSet traversalRules, CoordinateSystem tileMap)
            :base(actor)
        {
            this.traversalRules = traversalRules;
            this.tileMap = tileMap;
        }

        public override void Rotate()
        {
            base.Rotate();
        }

        public void MoveForward()
        {
            Console.WriteLine("Command: Forward");

            var nextMove = calculateMove(-Vector2.UnitY);

            //Cheap vector rounding
            nextMove = nextMove.ToPoint().ToVector2();

            nextMove += actor.GetPosition();
            executeMove(nextMove);
        }

        public void MoveLeft()
        {
            Console.WriteLine("Command: Left");

            var nextMove = calculateMove(-Vector2.UnitX);
            //Cheap vector rounding
            nextMove = nextMove.ToPoint().ToVector2();

            nextMove += actor.GetPosition();
            executeMove(nextMove);
        }

        public void MoveRight()
        {
            Console.WriteLine("Command: Right");

            var nextMove = calculateMove(Vector2.UnitX);
            //Cheap vector rounding
            nextMove = nextMove.ToPoint().ToVector2();

            nextMove += actor.GetPosition();
            executeMove(nextMove);
        }

        private Vector2 calculateMove(Vector2 input)
        {
            Vector2 output = input;
            Matrix rotationMatrix = Matrix.CreateRotationZ(actor.GetRotation());
            output = Vector2.Transform(output, rotationMatrix);

            return output;
        }

        private void executeMove(Vector2 destination)
        {
            var destinationPoint = destination.ToPoint();

            bool isInBoundsX = destinationPoint.X >= 0;
            isInBoundsX = isInBoundsX && destinationPoint.X < tileMap.GetSizeX();

            bool isInBoundsY = destinationPoint.Y >= 0;
            isInBoundsY = isInBoundsY && destinationPoint.Y < tileMap.GetSizeY();

            if (isInBoundsX && isInBoundsY)
            {
                InteractionElement nextPositionInteraction = tileMap.GetElement(destinationPoint.X, destinationPoint.Y);

                Rule nextInteraction = traversalRules.GetInteraction(nextPositionInteraction);

                if (nextInteraction == null || nextInteraction.GetInteractionValue() == null)
                {
                    Console.WriteLine("Interaction not found, skipping");
                    return;
                }

                var nextInteractionValue = nextInteraction.GetInteractionValue();
                Console.WriteLine("Next Interaction: " + nextInteractionValue);
                Console.WriteLine("Next Coordinate: " + destinationPoint);


                switch (nextInteractionValue)
                {
                    case "rock":
                        Console.WriteLine("Collided with rock");
                        break;
                    case "spinner":
                        Console.WriteLine("Contact with spinner");
                        actor.UpdatePosition(destination);
                        Rotate();
                        break;
                    case "hole":
                        var teleportDestination = tileMap.GetTeleporterDestination(destinationPoint.X, destinationPoint.Y);
                        Console.WriteLine("Fell into Hole");
                        Console.WriteLine("New Destination: " + teleportDestination);
                        actor.UpdatePosition(teleportDestination);
                        break;
                    case "none":
                        actor.UpdatePosition(destination);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Collided with edge of map");
                Console.WriteLine("Current Position: " + actor.GetPosition());
            }
        }
    }
}

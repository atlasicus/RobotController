namespace RobotController.Navigation.Interface
{
    interface Behavior
    {
        void MoveNorth();
        void MoveSouth();
        void MoveWest();
        void MoveEast();

        void Rotate();
    }
}

using RobotController.Navigation.Implementation;

namespace RobotControllerTest.Utils
{
    //A less elegant solution to what I had intended for a NavManager
    static class InputInterpreter
    {
        public static void NextMove(string input, ref AcceptanceNavigationManager navManager)
        {
            switch (input.ToUpper())
            {
                case "F":
                    navManager.MoveForward();
                    break;
                case "L":
                    navManager.MoveLeft();
                    break;
                case "R":
                    navManager.MoveRight();
                    break;
            }
        }
    }
}

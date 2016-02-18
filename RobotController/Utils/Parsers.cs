using System.Collections.Generic;

namespace RobotController.Utils
{
    public static class Parsers
    {
        public static Queue<string> TokenizeToFIFOQueue(string input)
        {
            Queue<string> inputTokens = new Queue<string>();
            char[] inputList = input.ToCharArray();

            foreach(char token in inputList)
            {
                inputTokens.Enqueue(token.ToString());
            }

            return inputTokens;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotControllerTest.Utils
{
    public static class Parsers
    {
        public static Queue<string> TokenizeToFIFOQueue(string input)
        {
            Queue<string> inputTokens = new Queue<string>();
            char[] inputList = input.ToCharArray();

            foreach (char token in inputList)
            {
                inputTokens.Enqueue(token.ToString());
            }

            return inputTokens;
        }
    }
}

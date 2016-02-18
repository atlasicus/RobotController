using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotControllerTest.Utils
{
    static class Results
    {
        static List<string> ResultList = new List<string>();

        public static void AddResult(string input)
        {
            ResultList.Add(input);
        }

        public static List<string> GetResults()
        {
            return ResultList;
        }
    }
}

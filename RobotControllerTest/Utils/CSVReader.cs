using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RobotControllerTest.Utils
{
    public static class CSVReader
    {
        public static byte[,] GetSymmetrical(string fileName)
        {
            List<byte[]> rowStore = new List<byte[]>();
            List<byte> elementIntermediary = new List<byte>();

            string line;
            using (StreamReader file = new StreamReader(fileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] tokens = line.Split(',');
                    foreach (string token in tokens)
                    {
                        elementIntermediary.Add(byte.Parse(token));
                    }
                    rowStore.Add(elementIntermediary.ToArray());
                    elementIntermediary.Clear();
                }
            }

            byte[,] returnValue = new byte[rowStore.Count, rowStore[0].Length];

            for (int i = 0; i < rowStore.Count; ++i)
            {
                for (int j = 0; j < rowStore[0].Length; ++j)
                {
                    returnValue[i, j] = rowStore[j][i];
                }
            }

            return returnValue;
        }
    }
}

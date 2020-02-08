using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BoT.Business.Utilities
{
    public class CSVHelper
    {
        public static string[] ReadLine(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            return File.ReadAllLines(filePath);
        }

        public static string[] ParseLine(string line, char delimiter)
        {
            return line.Split(delimiter);
        }

        

    }
}

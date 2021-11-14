using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPACalculatorRefix.Commons
{
    public static class Utilities
    {
        // clean string to remove digit at the begining
        public static string RemoveDigitFromStart(string str)
        {
            var temp = str;
            for (int i = 0; i < str.Length; i++)
            {
                char firstChar = str[i];

                if (((int)firstChar) >= ((int)'a') && ((int)firstChar) <= ((int)'z') ||
                    ((int)firstChar) >= ((int)'A') && ((int)firstChar) <= ((int)'Z'))
                {
                    temp = temp.Substring(i);
                    break;
                }

            }

            return temp;
        }

        // Change first character to caps
        public static string FirstCharacterToUpper(string val)
        {
            string v = val[0].ToString().ToUpper();
            string str = v;
            return (str += val.Substring(1));
        }

        #region PRINT TABLE UTILITY CODE
        public static void PrintLine(int widthOfTable)
        {
            Console.WriteLine(new string('-', widthOfTable));
        }

        public static void PrintRow(int widthOfTable, params string[] columns)
        {
            int width = (widthOfTable - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += CenterText(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string CenterText(string column, int width)
        {
            column = column.Length > width ? column.Substring(0, width - 3) + "..." : column;

            if (!string.IsNullOrEmpty(column))
            {
                return column.PadRight(width - (width - column.Length) / 2).PadLeft(width);
            }
            else
            {
                return new string(' ', width);
            }
        }

        #endregion



        public static string GetApsolutePath(string pathExtension)
        {
            var path = Directory.GetCurrentDirectory();

            var splittedPath = path.Split("/");
            var newPath = "";

            for (int i = 0; i < splittedPath.Length; i++)
            {
                if (splittedPath[i].Trim().Equals("GPACalculator"))
                {
                    newPath += splittedPath[i];
                    break;
                }

                newPath += splittedPath[i] + "/";
            }
            return newPath + pathExtension;
        }

    }
}

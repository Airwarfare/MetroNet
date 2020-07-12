using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MetroNet
{

    public class RegularExpressions
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ParseTimestamp("2014-08-18T13:03:25Z"));
            Console.WriteLine(ParseTimestamp("2014/08/18T13:03:25Z"));
            Console.WriteLine(ParseTimestamp("2014-08-18"));
            Console.WriteLine(ParseTimestamp("2014/08/18"));
        }

        public static DateTime ParseTimestamp(string timestamp)
        {
            //Cast to array: https://stackoverflow.com/a/12730562
            int[] timestampArray = Regex.Matches(timestamp, @"([0-9]+)").Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();

            //Dirty DateTime conversion, just showing that when put in a DateTime object it is the correct values (easier for logging)
            DateTime dateTime = new DateTime();
            if (timestampArray.Length == 3)
            {
                
                dateTime = new DateTime(timestampArray[0], timestampArray[1], timestampArray[2]);
            }
            else if (timestampArray.Length == 6)
            {
                dateTime = new DateTime(timestampArray[0], timestampArray[1], timestampArray[2], timestampArray[3], timestampArray[4], timestampArray[5]);
            }
            return dateTime;
        }
    }
}

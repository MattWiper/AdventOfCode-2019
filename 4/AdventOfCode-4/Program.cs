using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int start = 158126;
            const int end = 624574;

            List<string> validPasswords = new List<string>(); 

            foreach (int possiblePassword in Enumerable.Range(start, end))
            {
                var tempPosPassword = possiblePassword
                    .ToString()
                    .ToCharArray();

                if(HasDuplicateChars(tempPosPassword) && NumberNeverDecreases(tempPosPassword))
                {
                    validPasswords.Add(new string(tempPosPassword));
                }
            }
        }

        private static bool HasDuplicateChars(char[] testValue) => testValue
            .Zip(testValue
                .Skip(1), (n, m) => new { n, m })
            .Any(x => x.n == x.m);

        private static bool NumberNeverDecreases(char[] testValue)
        {
            char prevVal = ' ';

            foreach(var testChar in testValue)
            {
                if (prevVal == ' ')
                {
                    prevVal = testChar;
                    continue; 
                }

                if (prevVal <= testChar)
                {
                    prevVal = testChar;
                    continue; 
                }
    
                return false; 
            }

            return true;
        }
    }
}

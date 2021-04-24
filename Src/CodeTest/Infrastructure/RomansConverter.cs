using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Web.Infrastructure
{
    public interface IRomansConverter
    {
        int FromNumeral(string input);
    }

    public class RomansConverter : IRomansConverter
    {
        internal int LookupChar(char input)
        {
            switch (input)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new ArgumentException("Invalid input char");
            }
        }

        public int FromNumeral(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            input = input.ToUpper();

            int calculatedResult = 0;

            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char currentChar = input[i];
                    int currentValue = LookupChar(currentChar);

                    bool isNotLastChar = i + 1 < input.Length;

                    if (isNotLastChar)
                    {
                        char nextChar = input[i + 1];
                        int nextValue = LookupChar(nextChar);

                        if (currentValue < nextValue)
                        {
                            calculatedResult = calculatedResult - currentValue;
                        }
                        else
                        {
                            calculatedResult = calculatedResult + currentValue;
                        }
                    }
                    else
                    {
                        calculatedResult = calculatedResult + currentValue;
                    }
                }
            }
            catch(ArgumentException ae)
            {
                //log error
                calculatedResult = 0;
            }

            return calculatedResult;
        }
    }
}

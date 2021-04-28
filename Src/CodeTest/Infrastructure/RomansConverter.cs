using System;

namespace CodeTest.Web.Infrastructure
{
    public interface IRomansConverter
    {
        int FromNumeral(string input);

        string ToNumeral(int input);
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
                //log error to logfile, but here we just print it
                Console.Out.WriteLine(ae.Message);
                calculatedResult = 0;
            }

            return calculatedResult;
        }

        public string ToNumeral(int input)
        {
            if (input >= 1000) return "M" + ToNumeral(input - 1000);

            if (input >= 900) return "CM" + ToNumeral(input - 900);

            if (input >= 500) return "D" + ToNumeral(input - 500);

            if (input >= 400) return "CD" + ToNumeral(input - 400);

            if (input >= 100) return "C" + ToNumeral(input - 100);

            if (input >= 90) return "XC" + ToNumeral(input - 90);

            if (input >= 50) return "L" + ToNumeral(input - 50);

            if (input >= 40) return "XL" + ToNumeral(input - 40);

            if (input >= 10) return "X" + ToNumeral(input - 10);

            if (input >= 9) return "IX" + ToNumeral(input - 9);

            if (input >= 5) return "V" + ToNumeral(input - 5);

            if (input >= 4) return "IV" + ToNumeral(input - 4);

            if (input >= 1) return "I" + ToNumeral(input - 1);

            return string.Empty;
        }
    }
}

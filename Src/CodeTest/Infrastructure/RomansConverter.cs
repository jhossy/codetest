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
        private readonly Dictionary<char, int> _numeralValues = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public RomansConverter()
        {
            
        }

        public int FromNumeral(string input)
        {
            if (string.IsNullOrEmpty(input)) return 0;

            input = input.ToUpper();

            int calculatedResult = 0;

            for(int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                int currentValue = _numeralValues.ContainsKey(currentChar) ? _numeralValues[currentChar] : 0;

                if (currentValue == 0) continue;

                char nextChar = i < (input.Length - 1) ? input[i + 1] : ' ';
                int nextValue = nextChar == ' ' ? 0 : _numeralValues[nextChar];

                if (currentValue < nextValue)
                {
                    calculatedResult = calculatedResult - currentValue;
                }
                else
                {
                    calculatedResult = calculatedResult + currentValue;
                }
            }

            return calculatedResult;
        }
    }
}

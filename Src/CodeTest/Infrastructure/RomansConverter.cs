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

            for(int i=0; i < input.Length; i++)
            {
                char current = input[i];
                int foundValue = _numeralValues.ContainsKey(current) ? _numeralValues[current] : 0;

                calculatedResult += foundValue;
            }

            return calculatedResult;
        }
    }
}

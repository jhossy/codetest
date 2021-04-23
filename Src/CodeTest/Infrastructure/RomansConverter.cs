using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Web.Infrastructure
{
    public interface IRomansConverter
    {
        int FromNumeral(string numeral);
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

        public int FromNumeral(string numeral)
        {
            throw new NotImplementedException();
        }
    }
}

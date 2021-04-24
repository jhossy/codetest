using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotZeroOrNegativeDigitRule : IValidationRule<int>
    {
        public bool IsSatisfiedBy(int candidate)
        {
            return candidate > 0;
        }
    }
}

using System.Linq;

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotOtherCharsThanRoman : IValidationRule<string>
    {
        private readonly char[] _romanChars = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        public bool IsSatisfiedBy(string candidate)
        {
            if (string.IsNullOrEmpty(candidate)) return false;

            candidate = candidate.ToUpper();

            for(int i = 0; i < candidate.Length; i++)
            {
                if (!_romanChars.Contains(candidate[i])) return false;
            }

            return true;
        }
    }
}

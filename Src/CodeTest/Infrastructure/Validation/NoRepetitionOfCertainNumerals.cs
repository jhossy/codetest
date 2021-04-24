using System.Linq;

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NoRepetitionOfCertainNumerals : IValidationRule<string>
    {
        private readonly char[] _allowedRepetitions = new char[] { 'I', 'X', 'M' };

        public bool IsSatisfiedBy(string candidate)
        {
            if (candidate.Length < 2) return true;

            candidate = candidate.ToUpper();

            for (int i = 0; i < candidate.Length; i++)
            {
                bool isLastChar = i + 1 == candidate.Length;

                if (isLastChar) return true;

                if (_allowedRepetitions.Any(ch => ch == candidate[i])) continue;

                if (candidate[i] == candidate[i + 1]) return false;
            }

            return true;
        }
    }
}

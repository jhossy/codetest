using CodeTest.Web.Infrastructure.Validation;
using System;
using System.Linq;

namespace CodeTest.Web.Infrastructure
{
    public interface INumeralsValidator
    {
        bool Validate(string numeralInput);
    }

    public class NumeralsValidator : INumeralsValidator
    {
        private readonly char[] _validChars = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        private readonly IValidationRule<string>[] _validationRules;

        public NumeralsValidator()
        {
            _validationRules = new IValidationRule<string>[] //TODO - replace with validation rule provider if time left
            {
                new NotFourSameLettersInARowRule(),
                new NoRepetitionOfCertainNumerals()
            };
        }

        public bool Validate(string numeralInput)
        {
            if (_validChars.Any(ch => ch.ToString().Equals(numeralInput, StringComparison.InvariantCultureIgnoreCase))) return true;

            foreach(IValidationRule<string> rule in _validationRules)
            {
                if (rule.IsSatisfiedBy(numeralInput)) continue;
            }

            return false;
        }
    }
}

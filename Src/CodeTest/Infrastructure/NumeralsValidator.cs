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

        private readonly IValidationRuleProvider<string> _validationRuleProvider;

        public NumeralsValidator(IValidationRuleProvider<string> validationRuleProvider)
        {
            _validationRuleProvider = validationRuleProvider ?? throw new ArgumentNullException(nameof(validationRuleProvider));
        }

        public bool Validate(string numeralInput)
        {
            if (_validChars.Any(ch => ch.ToString().Equals(numeralInput, StringComparison.InvariantCultureIgnoreCase))) return true;

            foreach(IValidationRule<string> rule in _validationRuleProvider.GetRules())
            {
                if (!rule.IsSatisfiedBy(numeralInput)) return false;
            }
            return true;
        }
    }    
}

using CodeTest.Web.Infrastructure.Validation;
using System;

namespace CodeTest.Web.Infrastructure
{
    public interface IDigitsValidator
    {
        bool Validate(int input);
    }

    public class DigitsValidator : IDigitsValidator
    {
        private readonly IValidationRuleProvider<int> _validationRuleProvider;

        public DigitsValidator(IValidationRuleProvider<int> validationRuleProvider)
        {
            _validationRuleProvider = validationRuleProvider ?? throw new ArgumentNullException(nameof(validationRuleProvider));
        }

        public bool Validate(int input)
        {
            foreach (IValidationRule<int> rule in _validationRuleProvider.GetRules())
            {
                if (!rule.IsSatisfiedBy(input)) return false;
            }
            return true;
        }
    }
}

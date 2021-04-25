namespace CodeTest.Web.Infrastructure.Validation
{
    public interface IValidationRuleProvider<T>
    {
        IValidationRule<T>[] GetRules();
    }

    public class ValidationRuleProvider : IValidationRuleProvider<string>
    {
        public IValidationRule<string>[] GetRules()
        {
            return new IValidationRule<string>[]
            {
                new NotFourSameLettersInARowRule(),
                new NoRepetitionOfCertainNumeralsRule(),
                new NotEmptyStringRule(),
                new NotOtherCharsThanRomanRule(),
                new NotMoreThanMinMaxNumeralRule()
            };
        }
    }

    public class DigitsRuleProvider : IValidationRuleProvider<int>
    {
        public IValidationRule<int>[] GetRules()
        {
            return new IValidationRule<int>[]
            {
                new NotZeroOrNegativeDigitRule(),
                new NotMoreThanMinMaxDigitRule()
            };
        }
    }
}

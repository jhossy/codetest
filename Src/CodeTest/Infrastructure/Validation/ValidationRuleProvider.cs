namespace CodeTest.Web.Infrastructure.Validation
{
    public interface IValidationRuleProvider
    {
        IValidationRule<string>[] GetRules();
    }

    public class ValidationRuleProvider : IValidationRuleProvider
    {
        public IValidationRule<string>[] GetRules()
        {
            return new IValidationRule<string>[]
            {
                new NotFourSameLettersInARowRule(),
                new NoRepetitionOfCertainNumeralsRule(),
                new NotEmptyStringRule()
            };
        }
    }
}

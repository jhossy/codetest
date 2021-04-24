namespace CodeTest.Web.Infrastructure.Validation
{
    public interface IValidationRuleProvider
    {
        INumeralsValidationRule<string>[] GetRules();
    }

    public class ValidationRuleProvider : IValidationRuleProvider
    {
        public INumeralsValidationRule<string>[] GetRules()
        {
            return new INumeralsValidationRule<string>[]
            {
                new NotFourSameLettersInARowRule(),
                new NoRepetitionOfCertainNumeralsRule(),
                new NotEmptyStringRule()
            };
        }
    }
}

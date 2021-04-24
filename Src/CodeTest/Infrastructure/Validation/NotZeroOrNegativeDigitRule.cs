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

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotMoreThanMinMaxDigitRule : IValidationRule<int>
    {
        public bool IsSatisfiedBy(int candidate)
        {
            return candidate > 0 && candidate < 4001;
        }
    }
}

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotEmptyStringRule : INumeralsValidationRule<string>
    {
        public bool IsSatisfiedBy(string candidate)
        {
            if (string.IsNullOrEmpty(candidate) || string.IsNullOrWhiteSpace(candidate)) return false;

            return true;
        }
    }
}

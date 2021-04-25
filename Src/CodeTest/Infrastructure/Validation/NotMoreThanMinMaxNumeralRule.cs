namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotMoreThanMinMaxNumeralRule : IValidationRule<string>
    {
        public bool IsSatisfiedBy(string candidate)
        {
            candidate = candidate.ToUpper();

            if (candidate.Length < 4) return true;

            if (candidate.StartsWith("MMMM") && candidate.Length > 4) return false;

            return true;
        }
    }
}

namespace CodeTest.Web.Infrastructure.Validation
{
    public class NotFourSameLettersInARowRule : INumeralsValidationRule<string>
    {
        public bool IsSatisfiedBy(string candidate)
        {
            if (candidate == null) return true;

            if (candidate.Length < 4) return true;

            candidate = candidate.ToUpper();

            for (int i = 0; i < candidate.Length; i++)
            {
                bool isThirdLastCharOrLater = candidate.Length <= i + 3;

                if (isThirdLastCharOrLater) return true;

                if (candidate[i] == 'M') return true;

                if (candidate[i] == candidate[i + 1] && candidate[i] == candidate[i + 2] && candidate[i] == candidate[i + 3]) return false;
            }

            return true;
        }
    }
}

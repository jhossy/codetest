namespace CodeTest.Web.Infrastructure.Validation
{
    public interface INumeralsValidationRule<T> where T : class
    {
        bool IsSatisfiedBy(T candidate);
    }
}

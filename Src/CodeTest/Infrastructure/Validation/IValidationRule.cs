namespace CodeTest.Web.Infrastructure.Validation
{
    public interface IValidationRule<T> where T : class
    {
        bool IsSatisfiedBy(T candidate);
    }
}

namespace CodeTest.Web.Infrastructure.Validation
{
    public interface IValidationRule<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}

using ErrorOr;

namespace PubCrawl.Core;

public interface IValidator<T>
{
    Task<List<Error>> ValidateAsync(T value);
}

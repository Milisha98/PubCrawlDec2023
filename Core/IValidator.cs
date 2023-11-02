using ErrorOr;

namespace PubCrawl.Core;

public interface IValidator<T>
{
    IEnumerable<Error> Validate(T value);
}

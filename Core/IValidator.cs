using ErrorOr;

namespace PubCrawlDec2023.Core;

public interface IValidator<T>
{
    IEnumerable<Error> Validate(T value);
}

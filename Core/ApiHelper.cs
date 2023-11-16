using ErrorOr;

namespace PubCrawl.Core;

internal static class DareApiHelper
{
    public static IResult Ok<T>(this T model) => TypedResults.Ok(model);
    public static IResult Ok<T>(this List<T> models) => TypedResults.Ok(models);
    public static IResult OkOrNotFound<T>(this T? model) => model is null ? TypedResults.NotFound(model) : TypedResults.Ok(model);

    public static IDictionary<string, string[]> ToModelStateDictionary(this List<Error> errors) =>
        errors.GroupBy(x => x.Code)
              .ToDictionary(g => g.Key, g => g.Select(x => x.Description).ToArray());

    public static IResult OkOrValidationProblem<T>(this ErrorOr<T> model) =>
        model.Match<IResult>
        (
            dare => TypedResults.Ok(dare),
            errors => TypedResults.ValidationProblem(errors.ToModelStateDictionary())
        );
}

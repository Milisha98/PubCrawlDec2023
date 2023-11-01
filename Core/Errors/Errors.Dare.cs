using ErrorOr;
using MongoDB.Bson.Serialization.Conventions;

namespace PubCrawlDec2023.Core.Errors;

public static partial class Errors
{
    public static class Dare
    {
        public static class Validation
        {
            public static Error DareNameRequired    => Error.Validation(code: "Dare.Validation.Required.DareName", description: "The DareName is required.");
            public static Error ImageRequired       => Error.Validation(code: "Dare.Validation.Required.Image", description: "The Image is required.");
            public static Error ScoreMustBePositive => Error.Validation(code: "Dare.Validation.ScoreMustBePositive", description: "The Score must be 1 or more.");
        }

    }
}

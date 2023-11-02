using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class Location
    {
        public static class Validation
        {
            public static Error LocationNameRequired => Error.Validation(code: "Location.Validation.Required.LocationName", description: "The Location Name is required.");
            public static Error SequenceMustBePositive => Error.Validation(code: "Location.Validation.SequenceMustBePositive", description: "The Sequence must be zero or more.");
            public static Error DuplicateLocationName => Error.Conflict(code: "Location.Validation.DuplicateLocationName", description: "This Location Name already exists.");
        }

    }
}

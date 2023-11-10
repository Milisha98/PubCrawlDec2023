using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class User
    {
        public static class Validation
        {
            public static Error CodeRequired => Error.Validation(code: "User.Validation.Required.Code", description: "The Code is required.");
            public static Error NameRequired => Error.Validation(code: "User.Validation.Required.Name", description: "The Name is required.");
            public static Error DuplicateUser => Error.Conflict(code: "User.Validation.Duplicate", description: "This User record already exists.");
        }

    }
}
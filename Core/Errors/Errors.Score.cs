using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class Score
    {
        public static class Validation
        {            
			public static Error DuplicateScore => Error.Conflict(code: "Score.Validation.Duplicate", description: "This Score record already exists.");
        }

    }
}		
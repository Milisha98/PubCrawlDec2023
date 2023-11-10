using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class QuizQuestion
    {
        public static class Validation
        {
            public static Error QuestionRequired => Error.Validation(code: "QuizQuestion.Validation.Required.Question", description: "The Question is required.");
            public static Error Answer1Required => Error.Validation(code: "QuizQuestion.Validation.Required.Answer1", description: "The Answer 1 is required.");
            public static Error Answer2Required => Error.Validation(code: "QuizQuestion.Validation.Required.Answer2", description: "The Answer 2 is required.");
            public static Error Answer3Required => Error.Validation(code: "QuizQuestion.Validation.Required.Answer3", description: "The Answer 3 is required.");
            public static Error Answer4Required => Error.Validation(code: "QuizQuestion.Validation.Required.Answer4", description: "The Answer 4 is required.");
            public static Error DuplicateQuizQuestion => Error.Conflict(code: "QuizQuestion.Validation.Duplicate", description: "This Quiz Question record already exists.");
        }

    }
}
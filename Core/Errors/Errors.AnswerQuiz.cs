using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class AnswerQuiz
    {
        public static class Validation
        {
            public static Error QuizIDRequired => Error.Validation(code: "AnswerQuiz.Validation.Required.QuizID", description: "The Quiz ID is required."); 
            public static Error UserIDRequired => Error.Validation(code: "AnswerQuiz.Validation.Required.UserID", description: "The User ID is required."); 
			public static Error DuplicateAnswerQuiz => Error.Conflict(code: "AnswerQuiz.Validation.Duplicate", description: "This Answer Quiz record already exists.");
        }

    }
}		
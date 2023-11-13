using ErrorOr;
using MediatR;
using PubCrawl.Core.Errors;
using PubCrawl.Quiz.Queries;
using PubCrawl.Quiz.Repo;

namespace PubCrawl.Quiz;

public class AnswerQuizValidator
{
    private readonly IMediator _mediator;
    public AnswerQuizValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(AnswerQuizDataModel answerQuiz)
    {
        var errors = Validate(answerQuiz).ToList();
		var list = await _mediator.Send(new ListAnswerQuizzesQuery());
		if (list.Any(x => ( answerQuiz.Id != x.Id ) && 
			 			  ( ( x.QuizID.Trim().ToLower() == answerQuiz.QuizID?.Trim().ToLower() ) ||
                                 ( x.UserID.Trim().ToLower() == answerQuiz.UserID?.Trim().ToLower() ) )))
		{
			errors.Add(Errors.AnswerQuiz.Validation.DuplicateAnswerQuiz);
		}
        return errors;

    }

    private static IEnumerable<Error> Validate(AnswerQuizDataModel answerQuiz) 
    {
		// Mandatory Validation
        if (string.IsNullOrWhiteSpace(answerQuiz.QuizID)) yield return Errors.AnswerQuiz.Validation.QuizIDRequired;
if (string.IsNullOrWhiteSpace(answerQuiz.UserID)) yield return Errors.AnswerQuiz.Validation.UserIDRequired;
		
		throw new NotImplementedException();
    }


}		
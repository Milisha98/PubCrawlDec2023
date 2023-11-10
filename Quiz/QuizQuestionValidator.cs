using ErrorOr;
using MediatR;
using PubCrawl.Core.Errors;
using PubCrawl.Quizes.Queries;
using PubCrawl.Quizes.Repo;

namespace PubCrawl.Quizes;

public class QuizQuestionValidator
{
    private readonly IMediator _mediator;
    public QuizQuestionValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(QuizQuestionDataModel quizQuestion)
    {
        var errors = Validate(quizQuestion).ToList();
        var list = await _mediator.Send(new ListQuizQuestionsQuery());
        if (list.Any(x => (quizQuestion.Id != x.Id) &&
                          (x.Question.Trim().ToLower() == quizQuestion.Question?.Trim().ToLower())))
        {
            errors.Add(Errors.QuizQuestion.Validation.DuplicateQuizQuestion);
        }
        return errors;

    }

    private static IEnumerable<Error> Validate(QuizQuestionDataModel quizQuestion)
    {
        // Mandatory Validation
        if (string.IsNullOrWhiteSpace(quizQuestion.Question)) yield return Errors.QuizQuestion.Validation.QuestionRequired;
        if (string.IsNullOrWhiteSpace(quizQuestion.Answer1)) yield return Errors.QuizQuestion.Validation.Answer1Required;
        if (string.IsNullOrWhiteSpace(quizQuestion.Answer2)) yield return Errors.QuizQuestion.Validation.Answer2Required;
        if (string.IsNullOrWhiteSpace(quizQuestion.Answer3)) yield return Errors.QuizQuestion.Validation.Answer3Required;
        if (string.IsNullOrWhiteSpace(quizQuestion.Answer4)) yield return Errors.QuizQuestion.Validation.Answer4Required;

    }

}
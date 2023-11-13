using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Quiz.Repo;

namespace PubCrawl.Quiz.Commands;

public record InsertAnswerQuizCommand(string QuizID, string UserID, int Points) : IRequest<ErrorOr<AnswerQuizDataModel>>;

public class InsertAnswerQuizHandler : IRequestHandler<InsertAnswerQuizCommand, ErrorOr<AnswerQuizDataModel>>
{
    public readonly IValidator<AnswerQuizDataModel> _validator;
    public readonly AnswerQuizWriteRepo _repo;

    public InsertAnswerQuizHandler(IValidator<AnswerQuizDataModel> validator, AnswerQuizWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<AnswerQuizDataModel>> Handle(InsertAnswerQuizCommand request, CancellationToken cancellationToken)
    {
        var answerQuiz = new AnswerQuizDataModel(null, request.QuizID, request.UserID, request.Points);
        var validation = await _validator.ValidateAsync(answerQuiz);
        if (validation.Any())
        {
            return validation;
        }

        answerQuiz = await _repo.UpsertAsync(answerQuiz, cancellationToken);

        return answerQuiz;

    }
}		
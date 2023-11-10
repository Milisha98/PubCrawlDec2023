using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Quizes.Repo;

namespace PubCrawl.Quizes.Commands;

public record UpdateQuizQuestionCommand(string QuizQuestionID, string Question, string Answer1, string Answer2, string Answer3, string Answer4, int Answer) : IRequest<ErrorOr<QuizQuestionDataModel>>;

public class UpdateQuizQuestionHandler : IRequestHandler<UpdateQuizQuestionCommand, ErrorOr<QuizQuestionDataModel>>
{
    public readonly IValidator<QuizQuestionDataModel> _validator;
    public readonly QuizQuestionWriteRepo _repo;
    
    public UpdateQuizQuestionHandler(IValidator<QuizQuestionDataModel> validator, QuizQuestionWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<QuizQuestionDataModel>> Handle(UpdateQuizQuestionCommand request, CancellationToken cancellationToken)
    {
        var quizQuestion = new QuizQuestionDataModel(request.QuizQuestionID, request.Question, request.Answer1, request.Answer2, request.Answer3, request.Answer4, request.Answer);
        var validation = await _validator.ValidateAsync(quizQuestion);
        if (validation.Any()) 
        { 
            return validation;
        }

        quizQuestion = await _repo.UpsertAsync(quizQuestion, cancellationToken);

        return quizQuestion;

    }
}
using MediatR;
using PubCrawl.Quizes.Repo;

namespace PubCrawl.Quizes.Queries;

public record GetQuizQuestionQuery(string QuizQuestionID) : IRequest<QuizQuestionDataModel?>;

public class GetQuizQuestionHandler : IRequestHandler<GetQuizQuestionQuery, QuizQuestionDataModel?>
{
    private readonly QuizQuestionReadRepo _repo;

    public GetQuizQuestionHandler(QuizQuestionReadRepo repo)
    {
        _repo = repo;
    }

    public Task<QuizQuestionDataModel?> Handle(GetQuizQuestionQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.QuizQuestionID, cancellationToken);

}		
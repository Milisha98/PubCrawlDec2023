using MediatR;
using PubCrawl.Quiz.Repo;

namespace PubCrawl.Quiz.Queries;

public record GetAnswerQuizQuery(string AnswerQuizID) : IRequest<AnswerQuizDataModel?>;

public class GetAnswerQuizHandler : IRequestHandler<GetAnswerQuizQuery, AnswerQuizDataModel?>
{
    private readonly AnswerQuizReadRepo _repo;

    public GetAnswerQuizHandler(AnswerQuizReadRepo repo)
    {
        _repo = repo;
    }

    public Task<AnswerQuizDataModel?> Handle(GetAnswerQuizQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.AnswerQuizID, cancellationToken);

}		
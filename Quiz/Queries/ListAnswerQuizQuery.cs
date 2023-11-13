using MediatR;
using PubCrawl.Quiz.Repo;

namespace PubCrawl.Quiz.Queries;

public record ListAnswerQuizzesQuery() : IRequest<List<AnswerQuizDataModel>>;

public class ListAnswerQuizzesHandler : IRequestHandler<ListAnswerQuizzesQuery, List<AnswerQuizDataModel>>
{
    private readonly AnswerQuizReadRepo _repo;

    public ListAnswerQuizzesHandler(AnswerQuizReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<AnswerQuizDataModel>> Handle(ListAnswerQuizzesQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}		
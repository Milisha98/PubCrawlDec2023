using MediatR;
using PubCrawl.Quizes.Repo;

namespace PubCrawl.Quizes.Queries;

public record ListQuizQuestionsQuery() : IRequest<List<QuizQuestionDataModel>>;

public class ListQuizQuestionsHandler : IRequestHandler<ListQuizQuestionsQuery, List<QuizQuestionDataModel>>
{
    private readonly QuizQuestionReadRepo _repo;

    public ListQuizQuestionsHandler(QuizQuestionReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<QuizQuestionDataModel>> Handle(ListQuizQuestionsQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}		
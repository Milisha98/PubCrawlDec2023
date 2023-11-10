using MediatR;
using PubCrawl.Quizes.Repo;

namespace PubCrawl.Quizes.Commands;

public record DeleteQuizQuestionCommand(string QuizQuestionID) : IRequest<bool>;

public class DeleteQuizQuestionHandler : IRequestHandler<DeleteQuizQuestionCommand, bool>
{
    public readonly QuizQuestionWriteRepo _repo;

    public DeleteQuizQuestionHandler(QuizQuestionWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteQuizQuestionCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.QuizQuestionID, cancellationToken);
}		
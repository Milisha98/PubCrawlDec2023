using MediatR;
using PubCrawl.Quiz.Repo;

namespace PubCrawl.Quiz.Commands;

public record DeleteAnswerQuizCommand(string AnswerQuizID) : IRequest<bool>;

public class DeleteAnswerQuizHandler : IRequestHandler<DeleteAnswerQuizCommand, bool>
{
    public readonly AnswerQuizWriteRepo _repo;

    public DeleteAnswerQuizHandler(AnswerQuizWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteAnswerQuizCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.AnswerQuizID, cancellationToken);
}		
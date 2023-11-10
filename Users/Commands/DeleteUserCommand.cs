using MediatR;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users.Commands;

public record DeleteUserCommand(string UserID) : IRequest<bool>;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    public readonly UserWriteRepo _repo;

    public DeleteUserHandler(UserWriteRepo repo)
    {
        _repo = repo;
    }

    public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken) =>
        _repo.DeleteAsync(request.UserID, cancellationToken);
}		
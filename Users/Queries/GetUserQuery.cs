using MediatR;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users.Queries;

public record GetUserQuery(string UserID) : IRequest<UserDataModel?>;

public class GetUserHandler : IRequestHandler<GetUserQuery, UserDataModel?>
{
    private readonly UserReadRepo _repo;

    public GetUserHandler(UserReadRepo repo)
    {
        _repo = repo;
    }

    public Task<UserDataModel?> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
        _repo.GetByIDAsync(request.UserID, cancellationToken);

}		
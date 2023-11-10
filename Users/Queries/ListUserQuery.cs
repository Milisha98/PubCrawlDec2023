using MediatR;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users.Queries;

public record ListUsersQuery() : IRequest<List<UserDataModel>>;

public class ListUsersHandler : IRequestHandler<ListUsersQuery, List<UserDataModel>>
{
    private readonly UserReadRepo _repo;

    public ListUsersHandler(UserReadRepo repo)
    {
        _repo = repo;
    }

    public Task<List<UserDataModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken) =>
        _repo.ListAsync(cancellationToken);

}		
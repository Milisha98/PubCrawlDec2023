using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users.Commands;

public record InsertUserCommand(string Code, string Name, int Pokemon, bool IsActive) : IRequest<ErrorOr<UserDataModel>>;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ErrorOr<UserDataModel>>
{
    public readonly IValidator<UserDataModel> _validator;
    public readonly UserWriteRepo _repo;

    public InsertUserHandler(IValidator<UserDataModel> validator, UserWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<UserDataModel>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserDataModel(null, request.Code, request.Name, request.Pokemon, request.IsActive);
        var validation = await _validator.ValidateAsync(user);
        if (validation.Any())
        {
            return validation;
        }

        user = await _repo.UpsertAsync(user, cancellationToken);

        return user;

    }
}		
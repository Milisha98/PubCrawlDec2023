using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users.Commands;

public record UpdateUserCommand(string UserID, string Code, string Name, int Pokemon, bool IsActive) : IRequest<ErrorOr<UserDataModel>>;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ErrorOr<UserDataModel>>
{
    public readonly IValidator<UserDataModel> _validator;
    public readonly UserWriteRepo _repo;
    
    public UpdateUserHandler(IValidator<UserDataModel> validator, UserWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<UserDataModel>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserDataModel(request.UserID, request.Code, request.Name, request.Pokemon, request.IsActive);
        var validation = await _validator.ValidateAsync(user);
        if (validation.Any()) 
        { 
            return validation;
        }

        user = await _repo.UpsertAsync(user, cancellationToken);

        return user;

    }
}
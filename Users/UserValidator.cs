using ErrorOr;
using MediatR;
using PubCrawl.Core.Errors;
using PubCrawl.Users.Queries;
using PubCrawl.Users.Repo;

namespace PubCrawl.Users;

public class UserValidator
{
    private readonly IMediator _mediator;
    public UserValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(UserDataModel user)
    {
        var errors = Validate(user).ToList();
        var list = await _mediator.Send(new ListUsersQuery());
        if (list.Any(x => (user.Id != x.Id) &&
                           ((x.Code.Trim().ToLower() == user.Code?.Trim().ToLower()) ||
                            (x.Name.Trim().ToLower() == user.Name?.Trim().ToLower()))))
        {
            errors.Add(Errors.User.Validation.DuplicateUser);
        }
        return errors;

    }

    private static IEnumerable<Error> Validate(UserDataModel user)
    {
        // Mandatory Validation
        if (string.IsNullOrWhiteSpace(user.Code)) yield return Errors.User.Validation.CodeRequired;
        if (string.IsNullOrWhiteSpace(user.Name)) yield return Errors.User.Validation.NameRequired;

    }


}
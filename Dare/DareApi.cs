using MediatR;
using PubCrawl.Core;
using PubCrawl.Dare.Commands;
using PubCrawl.Dare.Queries;
namespace PubCrawl.Dare;

public static class DareApi
{
    public static void Register(WebApplication app)
    {
        var group = app.MapGroup("/api/Dares").WithOpenApi();
        group.MapGet("/", GetAllDares).WithName("GetAllDares").WithOpenApi();
        //group.MapGet("/{id}", GetDareById).WithName("GetDareById");
        //group.MapPut("/{id}", UpdateDare).WithName("UpdateDare");
        //group.MapPost("/", CreateDare).WithName("CreateDare");
        //group.MapDelete("/{id}", DeleteDare).WithName("DeleteDare");

    }

    public static async Task<IResult> GetAllDares(IMediator mediator) =>
        (await mediator.Send(new ListDaresQuery())).Ok();

    public static async Task<IResult> GetDareById(IMediator mediator, string id) =>
        (await mediator.Send(new GetDareQuery(id))).OkOrNotFound();

    public static async Task<IResult> UpdateDare(IMediator mediator, UpdateDareCommand command) =>
        (await mediator.Send(command)).OkOrValidationProblem();

    public static async Task<IResult> CreateDare(IMediator mediator, InsertDareCommand command) =>
        (await mediator.Send(command)).OkOrValidationProblem();

    public static async Task<IResult> DeleteDare(IMediator mediator, string id) =>
        TypedResults.Ok(await mediator.Send(new DeleteDareCommand(id)));

}


using ErrorOr;
using MediatR;
using PubCrawl.Core.Errors;
using PubCrawl.MessageLogs.Repo;

namespace PubCrawl.MessageLogs;

public class MessageLogValidator
{
    private readonly IMediator _mediator;
    public MessageLogValidator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Error>> ValidateAsync(MessageLogDataModel messageLog)
    {
        var errors = Validate(messageLog).ToList();
		
        return await Task.FromResult(errors);

    }

    private static IEnumerable<Error> Validate(MessageLogDataModel messageLog) 
    {
		// Mandatory Validation
        if (string.IsNullOrWhiteSpace(messageLog.Message)) yield return Errors.MessageLog.Validation.MessageRequired;
    }


}		
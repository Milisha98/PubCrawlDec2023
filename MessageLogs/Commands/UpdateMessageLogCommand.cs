using ErrorOr;
using MediatR;
using PubCrawl.Core;
using PubCrawl.MessageLogs.Repo;

namespace PubCrawl.MessageLogs.Commands;

public record UpdateMessageLogCommand(string MessageLogID, DateTime When, string Message) : IRequest<ErrorOr<MessageLogDataModel>>;

public class UpdateMessageLogHandler : IRequestHandler<UpdateMessageLogCommand, ErrorOr<MessageLogDataModel>>
{
    public readonly IValidator<MessageLogDataModel> _validator;
    public readonly MessageLogWriteRepo _repo;
    
    public UpdateMessageLogHandler(IValidator<MessageLogDataModel> validator, MessageLogWriteRepo repo)
    {
        _validator = validator;
        _repo 	   = repo;
    }

    public async Task<ErrorOr<MessageLogDataModel>> Handle(UpdateMessageLogCommand request, CancellationToken cancellationToken)
    {
        var messageLog = new MessageLogDataModel(request.MessageLogID, request.When, request.Message);
        var validation = await _validator.ValidateAsync(messageLog);
        if (validation.Any()) 
        { 
            return validation;
        }

        messageLog = await _repo.UpsertAsync(messageLog, cancellationToken);

        return messageLog;

    }
}
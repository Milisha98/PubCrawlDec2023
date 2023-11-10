using ErrorOr;

namespace PubCrawl.Core.Errors;

public static partial class Errors
{
    public static class MessageLog
    {
        public static class Validation
        {
            public static Error MessageRequired => Error.Validation(code: "MessageLog.Validation.Required.Message", description: "The Message is required."); 
			
        }

    }
}		
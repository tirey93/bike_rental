using Rebus.Handlers;
using Microsoft.Extensions.Logging;

namespace StationService.Handlers
{
    // Musi być public!
    public class StringEventHandler : IHandleMessages<string>
    {
        private readonly ILogger<StringEventHandler> _logger;

        public StringEventHandler(ILogger<StringEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(string message)
        {
            await Task.CompletedTask;
        }
    }
}
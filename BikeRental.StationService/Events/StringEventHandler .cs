using Rebus.Handlers;

namespace StationService.Handlers
{
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
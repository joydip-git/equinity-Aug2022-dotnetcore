namespace ServicesDemo.Services
{
    public class OperationService : ISingletionOperationService, IScopedOperationService, ITransientOperationService
    {
        public ILogger<OperationService> Logger { get; set; }
        public OperationService(ILogger<OperationService> logger)
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
            Logger = logger;
        }
        public string OperationId { get; }

        public void WriteMessage()
        {
            Logger.LogInformation(OperationId);
        }
    }
}

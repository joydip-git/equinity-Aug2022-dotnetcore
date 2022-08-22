namespace ServicesDemo.Services
{
    public interface IOperationService
    {
        string OperationId { get; }
        void WriteMessage();
    }
    public interface ISingletionOperationService:IOperationService
    {
    }
    public interface IScopedOperationService : IOperationService
    {
    }
    public interface ITransientOperationService : IOperationService
    {
    }
}
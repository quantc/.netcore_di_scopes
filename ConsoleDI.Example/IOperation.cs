using static System.Guid;

namespace ConsoleDI.Example
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface ITransientOperation : IOperation
    {
    }

    public interface IScopedOperation : IOperation
    {
    }

    public interface ISingletonOperation : IOperation
    {
    }

    public class DefaultOperation : ITransientOperation, IScopedOperation, ISingletonOperation
    {
        public string OperationId { get; } = NewGuid().ToString()[^4..];
    }
}
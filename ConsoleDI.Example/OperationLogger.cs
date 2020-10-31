using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDI.Example
{
    class OperationLogger
    {
        private ITransientOperation _transientOperation;
        private IScopedOperation _scopedOperation;
        private ISingletonOperation _singletonOperation;

        //public OperationLogger(ITransientOperation transientOperation, IScopedOperation scopedOperation, ISingletonOperation singletonOperation)
        //{
        //    _transientOperation = transientOperation;
        //    _scopedOperation = scopedOperation;
        //    _singletonOperation = singletonOperation;
        //}

        public OperationLogger(ITransientOperation transientOperation, IScopedOperation scopedOperation, ISingletonOperation singletonOperation) =>
            (_transientOperation, _scopedOperation, _singletonOperation) =
            (transientOperation, scopedOperation, singletonOperation);

        public void LogOperations(string scope)
        {
            LogOperation(_transientOperation, scope, "Always different");
            LogOperation(_scopedOperation, scope, "Changes only with scope");
            LogOperation(_singletonOperation, scope, "Always the same");
        }

        static void LogOperation<T>(T operation, string scope, string message) where T : IOperation
        {
            Console.WriteLine($"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
        }

    }
}

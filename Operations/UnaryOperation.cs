using ModuleContracts.Abstractions.Operations;

namespace ModuleContracts.Operations
{
    public class UnaryOperation
    {
        public IOperation Operation { get; private set; }
        public OperationInOutData Data { get; private set; }

        public UnaryOperation(IOperation operation, OperationInOutData data)
        {
            Operation = operation;
            Data = data;
        }
    }
}

using ModuleContracts.Abstractions.Operations;

namespace ModuleContracts.Operations
{
    public class BinaryOperation
    {
        public IOperation Operation { get; private set; }
        public List<OperationInOutData> Data { get; private set; }

        public BinaryOperation(IOperation operation, List<OperationInOutData> data)
        {
            Operation = operation;
            Data = data;
        }
    }
}

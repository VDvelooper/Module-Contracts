namespace ModuleContracts.Abstractions.Operations
{
    public interface IOperation
    {
        public string OperationName { get; }
        public string OperationSymbol { get; }
        public int OperandCount { get; }
        public bool OperandBeforeSymbol { get; }
        public Type OperandType { get; }
        public OperationInOutData? Execute(List<string> input);
        public bool TryConvertToOprType(string raw, out OperationInOutData operands);
        public bool TryConvertToOprType(List<string> raw, out List<OperationInOutData>? operands);
    }
}
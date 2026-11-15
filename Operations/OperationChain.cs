namespace ModuleContracts.Operations
{
    public class OperationChain
    {
        public Dictionary<int, ArgumentOperation>? ArgumentOperations { get; private set; }
        public Dictionary<int, UnaryOperation>? UnaryOperations { get; private set; }
        public Dictionary<int, BinaryOperation>? BinaryOperations { get; private set; }

        public OperationChain(Dictionary<int, ArgumentOperation> argumentOperations, 
            Dictionary<int, UnaryOperation> unaryOperations, 
            Dictionary<int, BinaryOperation>? binaryOperations)
        { 
            ArgumentOperations = argumentOperations.Count > 0 ? argumentOperations : null;
            UnaryOperations = unaryOperations.Count > 0 ? unaryOperations : null;
            BinaryOperations = binaryOperations.Count > 0 ? binaryOperations : null;
        }
    }
}

using ModuleContracts.Abstractions;

namespace ModuleContracts.Operations
{
    public class OperationChain
    {
        public Dictionary<int, ArgumentOperation>? ArgumentOperations { get; private set; }
        public Dictionary<int, UnaryOperation>? UnaryOperations { get; private set; }
        public Dictionary<int, BinaryOperation>? BinaryOperations { get; private set; }
        public List<ParsedFlag>? Flags { get; private set; }
        public bool IsFlagged { get { return Flags.Count > 0; } }

        public OperationChain(Dictionary<int, ArgumentOperation> argumentOperations, 
            Dictionary<int, UnaryOperation> unaryOperations, 
            Dictionary<int, BinaryOperation> binaryOperations,
            List<ParsedFlag> parsedFlags)
        { 
            ArgumentOperations = argumentOperations.Count > 0 ? argumentOperations : null;
            UnaryOperations = unaryOperations.Count > 0 ? unaryOperations : null;
            BinaryOperations = binaryOperations.Count > 0 ? binaryOperations : null;
            Flags = parsedFlags.Count > 0 ? parsedFlags : null;
        }

        // idk hogy kell-e ez, csak átmásoltam a volt UserInput osztályból
        public bool TryGetFlag(FlagID id, out ParsedFlag? found)
        {
            if (Flags == null) { found = null; return false;}

            found = Flags.Where(x => x.FlagID == id).FirstOrDefault();
            return Flags.Where(x => x.FlagID == id).Any();
        }
    }
}

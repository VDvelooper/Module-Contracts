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

        public bool IsAnyDataTypeCorrect()
        {
            foreach (OperationInOutData oiod in Data)
            {
                if (oiod.DoubleValue != null)
                {
                    if (Operation.OperandType.GetType() != typeof(double))
                        continue;

                    return true;
                }
                else if (oiod.BoolValue != null)
                {
                    if (Operation.OperandType.GetType() != typeof(bool))
                        continue;

                    return true;
                }                
                else if (oiod.StringValue != null)
                {
                    if (Operation.OperandType.GetType() != typeof(string))
                        continue;

                    return true;
                }
            }
            return false;
        }

        public bool IsDataEmpty()
        {
            bool foundEmpty = false;

            foreach (OperationInOutData oiod in Data)
            {
                foundEmpty = string.IsNullOrWhiteSpace(oiod.StringValue) && oiod.BoolValue == null && oiod.DoubleValue == null;
            }

            return foundEmpty;
        }

    }
}

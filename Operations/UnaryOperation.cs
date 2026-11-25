using ModuleContracts.Abstractions.Operations;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ModuleContracts.Operations
{
    public class UnaryOperation
    {
        public IOperation Operation { get; private set; }
        public OperationInOutData Data { get; private set; }
        public string Raw
        {
            get
            {
                if (Operation.OperandBeforeSymbol)
                {
                    switch (Operation.OperandType)
                    {
                        case Type t when t == typeof(double):
                            return $"{this.Operation.OperationSymbol}{this.Data.DoubleValue}";
                        case Type t when t == typeof(bool):
                            return $"{this.Operation.OperationSymbol}{this.Data.BoolValue}";
                        case Type t when t == typeof(string):
                            return $"{this.Operation.OperationSymbol}{this.Data.StringValue}";
                        default:
                            return "";
                    }
                }
                else
                {
                    switch (Operation.OperandType)
                    {
                        case Type t when t == typeof(double):
                            return $"{this.Data.DoubleValue}{this.Operation.OperationSymbol}";
                        case Type t when t == typeof(bool):
                            return $"{this.Data.BoolValue}{this.Operation.OperationSymbol}";
                        case Type t when t == typeof(string):
                            return $"{this.Data.StringValue}{this.Operation.OperationSymbol}";
                        default:
                            return "";
                    }
                }
            }
        }

        public UnaryOperation(IOperation operation, OperationInOutData data)
        {
            Operation = operation;
            Data = data;
        }

        public bool IsAnyDataTypeCorrect()
        {
            if (Data.DoubleValue != null)
            {
                return true;
            }
            else if (Data.BoolValue != null)
            {
                return true;
            }
            else if (Data.StringValue != null)
            {
                return true;
            }
            else return false;
        }

        public bool IsDataEmpty()
        {
            return string.IsNullOrWhiteSpace(Data.StringValue) && Data.BoolValue == null && Data.DoubleValue == null;
        }
    }
}

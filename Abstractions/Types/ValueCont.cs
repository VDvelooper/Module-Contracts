namespace ModuleContracts.Abstractions.Types
{
    internal class ValueCont
    {
        private Type _type;
        private dynamic _value;
        internal dynamic Value 
        {
            get { return _value; } 
            set
            {
            }
        }

        internal ValueCont(dynamic value)
        {
            Value = value;
            _type = value.GetType();
        }
    }
}

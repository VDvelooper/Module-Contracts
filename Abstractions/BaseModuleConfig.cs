namespace ModuleContracts.Abstractions
{
    public sealed class BaseModuleConfig
    {
        public string? ModuleName { get; set; }
        public string? ModuleCommand { get; set; }
        public bool IsProgram { get; set; }
    }
}

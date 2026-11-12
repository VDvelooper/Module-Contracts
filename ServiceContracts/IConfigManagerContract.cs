using ModuleContracts.Abstractions;

namespace ModuleContracts.ServiceContracts
{
    public interface IConfigManagerContract
    {
        string MainDirectoryPath { get; }
        BaseModuleConfig? LoadBaseModuleConfig(string path, out bool ignoreNullValue);
    }
}

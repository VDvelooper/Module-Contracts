using ModuleContracts.Feedback.Expected;
using ModuleContracts.Feedback;
using ModuleContracts.Feedback.Error;

namespace ModuleContracts.Abstractions
{
    public abstract class ModuleBase
    {
        public string ModuleName { get; private set; }
        public string ModuleCommand { get; private set; }
        public bool IsProgram { get; private set; }
        public bool ModuleConfigLoaded { get; private set; }
        
        public List<ICommand> BaseCommands { get; private set; }
        public List<ICommand> SubCommands { get; private set; }


        public Contracts Contracts { get; private set; }
        public string ModuleDataPath { get; }
        public string ModuleBaseConfigPath { get; }
        public string DllFilePath { get; private set; }


        private bool _isProgramRunning;

        public bool IsProgramRunning
        {
            get { return _isProgramRunning; }
            set // később problémás lehet hogy nem internal vagy más
            {
                _isProgramRunning = value;
            }
        }

        
        public ModuleBase(Contracts contract, string dllFilePath)
        {
            Contracts = contract;
            DllFilePath = dllFilePath;

            ModuleDataPath = @$"{Contracts.ConfigManagerContract.MainDirectoryPath}\ModuleData\{Path.GetFileNameWithoutExtension(DllFilePath)}";
            ModuleBaseConfigPath = @$"{ModuleDataPath}\config.json";

            if (!Path.Exists(ModuleDataPath))
            {
                Directory.CreateDirectory(ModuleDataPath);
            }

            ModuleConfigLoaded = TryLoadBaseModuleConfig();

            SubCommands = new List<ICommand>();

            CMD_Exit cmd_exit = new CMD_Exit("exit", 0, 0, "Exits the Module if it is a seperate program like module.", this);
            CMD_Help cmd_help = new CMD_Help("help", 0, 1, "Writes out all avalible commands in the current module.", this);
            CMD_ModuleExecute cmd_moduleExecute = new CMD_ModuleExecute(ModuleCommand, 0, int.MaxValue, "Writes out all avalible commands in the current module.", this);

            BaseCommands = new List<ICommand>()
            {
                cmd_exit,
                cmd_help,
                cmd_moduleExecute
            };
        }

        /// <summary>
        /// The manager of the Module. Calls the core logic and manages Separate Program Module functionality.
        /// </summary>
        public IFeedback ModuleExecute(UserInput userInput)
        {
            if (IsProgram) Entry();

            if (IsProgram) IsProgramRunning = true;

            IFeedback? feedback = null;

            feedback = ModuleBody(userInput);

            while (IsProgramRunning) 
            {
                feedback = ModuleBody(userInput);
            }

            if (IsProgram) Exit();

            return feedback ?? new ExpectedInput();
        }

        /// <summary>
        /// The very first thing that happenes when the ModuleExecute method is called.
        /// </summary>
        public virtual void Entry() { }
        /// <summary>
        /// The very last thing that happenes when the ModuleExecute method is at the end.
        /// </summary>
        public virtual void Exit() { }

        /// <summary>
        /// The the body of a Module. The Module's entry calls it. 
        /// </summary>
        /// <returns></returns>
        public abstract IFeedback? ModuleBody(UserInput userInput);

        private bool TryLoadBaseModuleConfig()
        {
            bool ignoreNullValue = false;
            BaseModuleConfig? loadedConfig = Contracts.ConfigManagerContract.LoadBaseModuleConfig(ModuleBaseConfigPath, out ignoreNullValue);
            
            if (ignoreNullValue)
            {
                return false;
            }

            if (loadedConfig == null)
            {
                Contracts.ConsoleViewContract.PresentFeedback(new InternalNullExeption());
                return false;
            }

            if (loadedConfig.ModuleName == string.Empty || loadedConfig.ModuleName == null ||
                loadedConfig.ModuleCommand == string.Empty || loadedConfig.ModuleCommand == null)
            {
                Contracts.ConsoleViewContract.PresentFeedback(new InternalNullExeption());
                return false;
            }

            ModuleName = loadedConfig.ModuleName!;
            ModuleCommand = loadedConfig.ModuleCommand!;
            IsProgram = loadedConfig.IsProgram;

            return true;
        }

        public void CloseProgram(object sender)
        {
            if (sender is not CMD_Exit && sender is not ModuleBase) { return; }

            IsProgramRunning = false;
        }
    }
}

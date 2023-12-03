using Talleres.Debugging;

namespace Talleres
{
    public class TalleresConsts
    {
        public const string LocalizationSourceName = "Talleres";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "85ea960ecab2484fba66c3d2964c79df";
    }
}

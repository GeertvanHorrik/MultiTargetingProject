namespace Ghk.MultiTargeting.Tool
{
    using System;
    using System.Diagnostics;
    using Catel.IoC;
    using Catel.Logging;

    internal class Program
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private static int Main(string[] args)
        {
#if DEBUG
            LogManager.AddDebugListener(true);
#endif

            var consoleLogListener = new ConsoleLogListener();
            LogManager.AddListener(consoleLogListener);

            var exitCode = 0;

            try
            {
                Log.Info("Example console app");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unknown exception occurred");
                exitCode = -1;
            }

#if DEBUG
            if (Debugger.IsAttached)
            {
                WaitForKeyPress();
            }
#endif

            return exitCode;
        }

        private static void WaitForKeyPress()
        {
            Log.Info(string.Empty);
            Log.Info("Press any key to continue");

            Console.ReadKey();
        }
    }
}

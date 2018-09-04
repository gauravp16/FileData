using System;
using Autofac;
using FileData.Infrastructure;
using log4net;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            if (!Validate(args))
            {
                Console.WriteLine("Invalid arguments supplied");
                Console.ReadLine();
                return;
            }

            App app;
            if (!Bootstrapper.Init(out app))
            {
                Console.WriteLine("Error while starting up the app, please contact support");
                Console.ReadLine();
                return;
            }

            try
            {
                var result = app.Query(args[1], args[0]);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Log.Error("Error while getting the file attribute", ex);
                Console.WriteLine(string.Format("Error : {0}", ex.Message));
            }
        }

        private static bool Validate(string[] args)
        {
            if (args == null || args.Length != 2)
                return false;

            return true;
        }
    }
}

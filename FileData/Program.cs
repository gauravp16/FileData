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
            App app;
            if (!Bootstrapper.Initialize(out app))
            {
                Console.WriteLine("Error while starting up the app, please contact support");
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
    }
}

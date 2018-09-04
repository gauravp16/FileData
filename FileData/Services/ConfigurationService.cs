using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData.Services
{
    /// <summary>
    /// Responsible for getting configuration values. Configuration store
    /// could be anything.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        public string[] AllowedSizePattern()
        {
            return ConfigurationManager.AppSettings["SizePattern"].Split(',');
        }

        public string[] AllowedVersionPattern()
        {
            return ConfigurationManager.AppSettings["VersionPattern"].Split(',');
        }
    }
}

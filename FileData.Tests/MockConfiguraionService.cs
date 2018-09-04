using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileData.Services;

namespace FileData.Tests
{
    public class MockConfiguraionService : IConfigurationService
    {
        public string[] AllowedSizePattern()
        {
            return new[] { "-s", "--size", "/s", "--s" };
        }

        public string[] AllowedVersionPattern()
        {
            return new[] { "-v", "--version", "/v", "--v" };
        }
    }
}

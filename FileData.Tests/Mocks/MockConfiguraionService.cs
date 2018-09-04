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

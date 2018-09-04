using FileData.Services;

namespace FileData.Tests
{
    public class MockFileAttributeService : IFileAttributeService
    {
        public string Size(string file)
        {
            return "100";
        }

        public string Version(string file)
        {
            return "1.0";
        }
    }
}

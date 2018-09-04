using FileData.Services;
using ThirdPartyTools;

namespace FileData.Services
{
    /// <summary>
    /// Responsible for getting the details out of third party api.
    /// </summary>
    public class FileAttributeService : IFileAttributeService
    {
        private FileDetails _fileDetails;

        public FileAttributeService(FileDetails fileDetails)
        {
            _fileDetails = fileDetails;
        }

        public string Size(string file)
        {
            return _fileDetails.Size(file).ToString();
        }

        public string Version(string file)
        {
            return _fileDetails.Version(file);

        }
    }
}

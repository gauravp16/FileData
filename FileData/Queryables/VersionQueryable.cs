using System;
using System.Configuration;
using System.Linq;
using FileData.Services;

namespace FileData
{
    /// <summary>
    /// Responsible for providing version of a file.
    /// </summary>
    public class VersionQueryable : FileAttribueQueryable
    {
        private IFileAttributeService _fileAttributeService;
        private IConfigurationService _configurationService;

        public VersionQueryable(IFileAttributeService fileAttributeService,
                                IConfigurationService configurationService)
        {
            _fileAttributeService = fileAttributeService;
            _configurationService = configurationService;
        }

        public override bool IsApplicable(string pattern)
        {
            var allowedPattern = _configurationService.AllowedVersionPattern();
            if (allowedPattern.Any(x => x.Trim().Equals(pattern, StringComparison.OrdinalIgnoreCase)))
                return true;

            return false;
        }

        protected override string Query(string file)
        {
            return _fileAttributeService.Version(file);
        }
    }
}

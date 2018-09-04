using System;
using System.Configuration;
using System.Linq;
using FileData.Services;

namespace FileData.Queryables
{
    /// <summary>
    /// Responsible for providing size of a file.
    /// </summary>
    public class SizeQueryable : FileAttribueQueryable
    {
        private IFileAttributeService _fileAttributeService;
        private IConfigurationService _configurationService;

        public SizeQueryable(IFileAttributeService fileAttributeService,
                             IConfigurationService configurationService)
        {
            _fileAttributeService = fileAttributeService;
            _configurationService = configurationService;
        }

        public override bool IsApplicable(string pattern)
        {
            var allowedPattern = _configurationService.AllowedSizePattern();
            if (allowedPattern.Any(x => x.Trim().Equals(pattern, StringComparison.OrdinalIgnoreCase)))
                return true;

            return false;
        }

        protected override string Query(string file)
        {
            return _fileAttributeService.Size(file);
        }
    }
}

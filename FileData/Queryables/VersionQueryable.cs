using System;
using System.Linq;
using FileData.Services;

namespace FileData
{
    public class VersionQueryable : FileAttribueQueryable
    {
        private string[] AllowedPattern = new[] { "-v", "--v", "/v", "--version" };
        private IFileAttributeService _fileAttributeService;

        public VersionQueryable(IFileAttributeService fileAttributeService)
        {
            _fileAttributeService = fileAttributeService;
        }

        public override bool IsApplicable(string pattern)
        {
            if (AllowedPattern.Any(x => x.Equals(pattern, StringComparison.OrdinalIgnoreCase)))
                return true;

            return false;
        }

        protected override string Query(string file)
        {
            return _fileAttributeService.Version(file);
        }
    }
}

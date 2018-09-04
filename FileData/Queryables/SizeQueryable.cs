using System;
using System.Linq;
using FileData.Services;

namespace FileData
{
    public class SizeQueryable : FileAttribueQueryable
    {
        private string[] AllowedPattern = new[] { "-s", "--s", "/s", "--size" };
        private IFileAttributeService _fileAttributeService;

        public SizeQueryable(IFileAttributeService fileAttributeService)
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
            return _fileAttributeService.Size(file);
        }
    }
}

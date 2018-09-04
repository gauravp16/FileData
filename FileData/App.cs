using System;
using FileData.Queryables;

namespace FileData
{
    /// <summary>
    /// Api for querying given file attribute.
    /// </summary>
    public class App
    {
        private FileAttribueQueryable[] _fileAttributeQueryables;

        public App(FileAttribueQueryable[] fileAttribueQueryables)
        {
            _fileAttributeQueryables = fileAttribueQueryables;
        }

        public string Query(string file, string parameter)
        {
            if(string.IsNullOrEmpty(file))
                throw new ArgumentException("Invalid file path");

            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentException("Invalid functionality");

            foreach (var queryable in _fileAttributeQueryables)
            {
                if (queryable.IsApplicable(parameter))
                    return queryable.Query(file, parameter);
            }

            //not supported feature
            throw new ArgumentException("Invalid pattern, does not match with any allowed values");
        }
    }
}

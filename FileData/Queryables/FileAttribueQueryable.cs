using System;

namespace FileData
{
    public abstract class FileAttribueQueryable
    {
        public abstract bool IsApplicable(string pattern);

        //template method
        public string Query(string file, string pattern)
        {
            if (!IsApplicable(pattern))
                throw new Exception("Pattern does not match allowed configuration values");

            return Query(file);
        }

        protected abstract string Query(string file);

    }
}

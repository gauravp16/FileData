using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData.Services
{
    public interface IConfigurationService
    {
        string[] AllowedSizePattern();

        string[] AllowedVersionPattern();
    }
}

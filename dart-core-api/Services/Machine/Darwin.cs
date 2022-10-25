using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core_api.Services.Machine
{
    public interface IDarwin
    {

    }
    public class Darwin
    {
        public OperatingSystem GetOperatingSystemInfo()
        {
            return Environment.OSVersion;
        }


    }
}

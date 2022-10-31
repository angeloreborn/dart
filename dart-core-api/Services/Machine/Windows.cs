using dart_core_api.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace dart_core_api.Services.Machine
{
    public interface IWindows
    {
        WindowsIdentity? GetIdentity();
        IAsyncEnumerable<string> Search(string folder, string extention);
    }

    [SupportedOSPlatform(OSPlatformType.Windows)]
    public class Windows : IWindows
    {
        private WindowsIdentity? _identity;
        public Windows()
        {
            _identity = GetIdentity();
        }

        public WindowsIdentity? GetIdentity() => WindowsIdentity.GetCurrent();

        public async IAsyncEnumerable<string> Search(string folder, string extention)
        {
            await Task.Run(() => { }); // or supress
            foreach (string file in Directory.EnumerateFiles(folder, $"*{extention}", SearchOption.AllDirectories))
            {
                yield return file;
            }
        }
    }
}

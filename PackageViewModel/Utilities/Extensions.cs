using NuGet;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageExplorerViewModel.Utilities
{
    public static class Extensions
    {
        public static long PackageSize(this IPackage package)
        {
            using (var s = package.GetStream())
                return s.Length;
        }

        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "InFolder")]
        public static IEnumerable<string> GetFilesInFolder(this IPackage package, string folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("folder");
            }

            if (String.IsNullOrEmpty(folder))
            {
                // return files at the root
                return from s in package.GetFiles()
                       where s.Path.IndexOf(Path.DirectorySeparatorChar) == -1
                       select s.Path;
            }
            else
            {
                string prefix = folder + Path.DirectorySeparatorChar;
                return from s in package.GetFiles()
                       where s.Path.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                       select s.Path;
            }
        }

        public static IEnumerable<string> GetFilesUnderRoot(this IPackage package)
        {
            return GetFilesInFolder(package, String.Empty);
        }
    }
}

using System.Collections.Generic;
using NuGetPe;
using NuGet;

namespace NuGetPackageExplorer.Types
{
    public interface IPackageRule
    {
        IEnumerable<PackageIssue> Validate(IPackage package, string packageFileName);
    }
}
using System;
using NuGet;
using PackageExplorerViewModel;

namespace NuGetPackageExplorer.Types
{
    public interface IPackageChooser : IDisposable
    {
        PackageInfo SelectPackage(string searchTerm);
        PackageInfo SelectPluginPackage();
    }
}
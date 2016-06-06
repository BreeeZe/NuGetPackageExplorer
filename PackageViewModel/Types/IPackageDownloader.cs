using System;
using System.Threading.Tasks;

namespace NuGetPackageExplorer.Types
{
    public interface IPackageDownloader
    {
        Task<NuGet.IPackage> Download(Uri downloadUri, string packageId, string packageVersion);
        Task Download(string targetFilePath, Uri downloadUri, string packageId, string packageVersion);
    }
}
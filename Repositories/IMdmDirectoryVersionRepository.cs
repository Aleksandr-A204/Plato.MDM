using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryVersionRepository
    {
        Task<MdmDirectoryVersion> AddVersionAsync();
        Task<MdmDirectoryVersion> EditVersionAsync(Guid id);
        Task<MdmDirectoryVersion> DeleteVersionAsync(Guid id);
        Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsAsync();
        Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId);
        Task<MdmDirectoryVersion> GetVersionByIdAsync(Guid id);
    }
}

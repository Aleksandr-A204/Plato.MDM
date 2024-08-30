using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryRepository
    {
        Task<bool> AddDirectoryAsync(MdmDirectory directory);
        Task<bool> UpdateDirectoryAsync(Guid id, MdmDirectory updatedDirectory);
        Task<bool> DeleteDirectoryAsync(Guid id);
        Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync();
        Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId);
        Task<MdmDirectory> GetDirectoryByIdAsync(Guid id);
    }
}

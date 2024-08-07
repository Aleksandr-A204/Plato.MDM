using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryRepository
    {
        bool AddDirectoryAsync(MdmDirectory directory);
        bool EditDirectoryAsync(MdmDirectory directory);
        bool DeleteDirectoryAsync(Guid id);
        Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync();
        Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId);
        Task<MdmDirectory> GetDirectoryByIdAsync(Guid id);
    }
}

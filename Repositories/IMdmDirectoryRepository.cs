using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryRepository
    {
        Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync();
        Task<MdmDirectory> EditDirectoryAsync(Guid id);
    }
}

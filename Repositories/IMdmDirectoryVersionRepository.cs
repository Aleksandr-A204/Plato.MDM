using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryVersionRepository
    {
        Task<IEnumerable<MdmDirectoryVersion>> GetAllDirectoryVersionsAsync();
    }
}

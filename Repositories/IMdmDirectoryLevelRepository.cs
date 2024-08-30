using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryLevelRepository
    {
        Task<IEnumerable<MdmDirectoryLevel>> GetAllLevelsAsync();
    }
}

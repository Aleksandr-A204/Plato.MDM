using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public interface IMdmDirectoryDomainRepository
    {
        Task<IEnumerable<MdmDirectoryDomain>> GetAllDomainsAsync();
    }
}

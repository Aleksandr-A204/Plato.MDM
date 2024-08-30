using Microsoft.EntityFrameworkCore;
using Plato.MDM.Data;
using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public class MdmDirectoryDomainRepository : IMdmDirectoryDomainRepository
    {
        private readonly MdmSystemContext _context;

        public MdmDirectoryDomainRepository(MdmSystemContext context) : base()
        {
            _context = context;
        }

        public async Task<IEnumerable<MdmDirectoryDomain>> GetAllDomainsAsync()
            => await _context.MdmDirectoryDomains.ToListAsync();
    }
}

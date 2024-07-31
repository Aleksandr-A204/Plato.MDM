using Microsoft.EntityFrameworkCore;
using Plato.MDM.Data;
using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public class MdmDirectoryVersionRepository : IMdmDirectoryVersionRepository
    {
        private readonly MdmSystemContext _context;
        public MdmDirectoryVersionRepository(MdmSystemContext context) : base()
        {
            _context = context;
        }

        public async Task<IEnumerable<MdmDirectoryVersion>> GetAllDirectoryVersionsAsync() =>
            await _context.MdmDirectoryVersions.Include(x => x.Directory).ToListAsync();
    }
}

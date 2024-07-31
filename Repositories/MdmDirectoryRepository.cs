using Microsoft.EntityFrameworkCore;
using Plato.MDM.Data;
using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public class MdmDirectoryRepository : IMdmDirectoryRepository
    {
        private readonly MdmSystemContext _context;

        public MdmDirectoryRepository(MdmSystemContext context) : base()
        {
            _context = context;
        }

        public async Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync() =>
            await _context.MdmDirectories.Include(x => x.DirectoryDomain).Include(x => x.DirectoryLevel).ToListAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using Plato.MDM.Data;
using Plato.MDM.Models;

namespace Plato.MDM.Repositories
{
    public class MdmDirectoryLevelRepository : IMdmDirectoryLevelRepository
    {
        private readonly MdmSystemContext _context;

        public MdmDirectoryLevelRepository(MdmSystemContext context) : base()
        {
            _context = context;
        }

        public async Task<IEnumerable<MdmDirectoryLevel>> GetAllLevelsAsync()
             => await _context.MdmDirectoryLevels.ToListAsync();
    }
}

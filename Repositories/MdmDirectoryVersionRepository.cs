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

        public Task<MdmDirectoryVersion> AddVersionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MdmDirectoryVersion> DeleteVersionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MdmDirectoryVersion> EditVersionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsAsync() =>
            await _context.MdmDirectoryVersions.Include(x => x.Directory).ToListAsync();

        public Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId)
        {
            throw new NotImplementedException();
        }

        public Task<MdmDirectoryVersion> GetVersionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

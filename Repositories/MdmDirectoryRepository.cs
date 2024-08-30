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

        public async Task<bool> AddDirectoryAsync(MdmDirectory directory)
        {
            await _context.MdmDirectories.AddAsync(directory);
            return await SaveAsync();
        }

        public async Task<bool> DeleteDirectoryAsync(Guid id)
        {
            var directory = await _context.MdmDirectories.FindAsync(id);
            if (directory == null) return false;

            _context.MdmDirectories.Remove(directory);
            return await SaveAsync();
        }

        public async Task<bool> UpdateDirectoryAsync(Guid id, MdmDirectory updatedDirectory)
        {
            var directory = await _context.MdmDirectories.Where(d => d.Id == id).FirstOrDefaultAsync();
            if (directory == null) return false;

            _context.Entry(directory).CurrentValues.SetValues(updatedDirectory);
            return await SaveAsync();
        }

        public async Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync()
            => await _context.MdmDirectories.Include(x => x.DirectoryDomain).Include(x => x.DirectoryLevel).ToListAsync();

        public async Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId) 
            => await _context.MdmDirectoryVersions.Include(x => x.Directory).ToListAsync();
        
        public async Task<MdmDirectory> GetDirectoryByIdAsync(Guid id)
            => await _context.MdmDirectories.FirstOrDefaultAsync(x => x.Id == id) ?? new MdmDirectory();

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

    }
}

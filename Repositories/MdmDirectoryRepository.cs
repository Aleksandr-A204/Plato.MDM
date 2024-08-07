using Microsoft.EntityFrameworkCore;
using Plato.MDM.Data;
using Plato.MDM.Models;
using System.IO;

namespace Plato.MDM.Repositories
{
    public class MdmDirectoryRepository : IMdmDirectoryRepository
    {
        private readonly MdmSystemContext _context;

        public MdmDirectoryRepository(MdmSystemContext context) : base()
        {
            _context = context;
        }

        public bool AddDirectoryAsync(MdmDirectory directory)
        {
            _context.Add(directory);
            return Save();
        }

        public bool DeleteDirectoryAsync(Guid id)
        {
            _context.Entry(id).State = EntityState.Modified;

            return Save();
        }

        public bool EditDirectoryAsync(MdmDirectory directory)
        {
            _context.Entry(directory).State = EntityState.Modified;
            return Save();
        }

        public async Task<IEnumerable<MdmDirectory>> GetAllDirectoriesAsync()
            => await _context.MdmDirectories.Include(x => x.DirectoryDomain).Include(x => x.DirectoryLevel).ToListAsync();

        public async Task<IEnumerable<MdmDirectoryVersion>> GetAllVersionsByDirectoryAsync(Guid directoryId) 
            => await _context.MdmDirectoryVersions.Include(x => x.Directory).ToListAsync();
        
        public async Task<MdmDirectory> GetDirectoryByIdAsync(Guid id)
            => await _context.MdmDirectories.FirstOrDefaultAsync(x => x.Id == id) ?? new MdmDirectory();

        public bool Save()
            => _context.SaveChanges() > 0;

    }
}

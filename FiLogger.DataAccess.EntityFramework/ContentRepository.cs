using PlinxPlanner.Common.Models;
using PlinxPlanner.Context.Data;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlinxPlanner.DataAccess.EntityFramework
{
    public class ContentRepository : IContentRepository
    {
        private readonly AP_ReplacementContext _context;

        public ContentRepository(AP_ReplacementContext context)
        {
            _context = context;
        }

        #region Get request
        public async Task<IEnumerable<DefaultContent>> GetDefaultContent() => await _context.DefaultContent.
            AsNoTracking().
            Include(x => x.DefaultComments).
            Include(x => x.DefaultExperiance).
            Include(x => x.DefaultPortfolio).
            Include(x => x.DefaultSkills)
            .ToListAsync();
        public async Task<DefaultContent> GetDefaultContent(int id) => await _context.DefaultContent.
            AsNoTracking().
            Include(x => x.DefaultComments).
            Include(x => x.DefaultExperiance).
            Include(x => x.DefaultPortfolio).
            Include(x => x.DefaultSkills).
            SingleOrDefaultAsync(i => i.DefaultContentId == id);
        #endregion

        #region Destructor       
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

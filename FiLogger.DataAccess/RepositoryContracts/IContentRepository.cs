using System.Collections.Generic;
using System.Threading.Tasks;
using PlinxPlanner.Common.Models;

namespace PlinxPlanner.DataAccess.Contracts.RepositoryContracts
{
    public interface IContentRepository
    {
        void Dispose();
        Task<IEnumerable<DefaultContent>> GetDefaultContent();
        Task<DefaultContent> GetDefaultContent(int id);
    }
}
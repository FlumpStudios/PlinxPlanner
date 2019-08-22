using System.Collections.Generic;
using System.Threading.Tasks;
using PlinxPlanner.Common.Models;

namespace PlinxPlanner.Service.Services
{
    public interface IContentService
    {
        Task<IEnumerable<DefaultContent>> GetDefaultContent();
        Task<DefaultContent> GetDefaultContent(int id);
    }
}
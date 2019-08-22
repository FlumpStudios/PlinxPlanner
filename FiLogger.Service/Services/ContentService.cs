using PlinxPlanner.Caching;
using PlinxPlanner.Common.Models;
using PlinxPlanner.DataAccess.Contracts.RepositoryContracts;
using PlinxPlanner.DataAccess.EntityFramework;
using PlinxPlanner.Service.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlinxPlanner.Service.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repository;
        private readonly ILogger<ContentService> _logger;

        public ContentService(
            IContentRepository repository,
            ILogger<ContentService> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        #region Get Methods
        public async Task<IEnumerable<DefaultContent>> GetDefaultContent()
        {
            try
            {
                return await _repository.GetDefaultContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Error Retrieving list of default content", e);
                throw;
            }
        }

        public async Task<DefaultContent> GetDefaultContent(int id)
        {

            DefaultContent content = null;

            try
            {
                content = await _repository.GetDefaultContent(id);
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format("Could not retrieve default content with the ID of {0}", id), e);
            }

            return content;
        }

        #endregion
    }
}

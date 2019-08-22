using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlinxPlanner.Service.Contracts;
using vm = PlinxPlanner.API.DataContracts;
using dm = PlinxPlanner.Common.Models;
using Microsoft.AspNetCore.Authorization;
using PlinxPlanner.Service.Services;

namespace PlinxPlanner.API.Controllers.V1
{
    /// <summary>
    /// Customer details controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContentService _service;

        /// <summary>
        /// Constructor method for the customer details controller
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ContentController(IMapper mapper,
             IContentService service)
        {
            _mapper = mapper;
            _service = service;
        }


        #region Get Requests
        /// <summary>
        /// Return full list of DefaultContent
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<IEnumerable<vm.Response.DefaultContent>>> Get()
        {
            return _mapper.Map<IEnumerable<vm.Response.DefaultContent>>(await _service.GetDefaultContent()).ToList();
        }

        /// <summary>
        /// Get DefaultContent via  ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<vm.Response.DefaultContent>> Get(int id)
        {
            return _mapper.Map<vm.Response.DefaultContent>(await _service.GetDefaultContent(id)); 
        }
        #endregion
    }
}

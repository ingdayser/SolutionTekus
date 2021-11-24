using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Api.Filter;
using Tekus.Core.Application.DTO.In;
using Tekus.Core.Application.Helpers;
using Tekus.Core.Application.ServicesContracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProviderController : Controller
    {
        private readonly IProviderAppService _providerAppService;
        public ProviderController(IProviderAppService serviceAppService)
        {
            this._providerAppService = serviceAppService;
        }

        // GET: Provider
        [HttpGet]       
        public async Task<RequestResult<List<ProviderDto>>> Index()
        {
            return await _providerAppService.GetAllAsync();
        }

        // GET: Provider/5
        [HttpGet]
        [Route("{id}")]
        public async Task<RequestResult<ProviderDto>> Details(Guid id)
        {
            return await _providerAppService.GetByIdAsync(id);
        }

        // POST: Provider/
        [HttpPost]
        [TypeFilter(typeof(ValidationFilter))]
        public async Task<RequestResult<ProviderDto>> Create([FromBody]ProviderDto providerDto)
        {
          return await _providerAppService.CreateAsync(providerDto);
        }     
    }
}

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
    public class ServiceController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        public ServiceController(IServiceAppService serviceAppService)
        {
            this._serviceAppService = serviceAppService;
        }

        // GET: Service
        [HttpGet]       
        public async Task<RequestResult<List<ServiceDto>>> Index()
        {
            return await _serviceAppService.GetAllAsync();
        }

        // GET: Service/5
        [HttpGet]
        [Route("{id}")]
        public async Task<RequestResult<ServiceDto>> Details(Guid id)
        {
            return await _serviceAppService.GetByIdAsync(id);
        }

        // POST: Service/
        [HttpPost]
        [TypeFilter(typeof(ValidationFilter))]
        public async Task<RequestResult<ServiceDto>> Create([FromBody]ServiceDto serviceDto)
        {
          return await _serviceAppService.CreateAsync(serviceDto);
        }     
    }
}

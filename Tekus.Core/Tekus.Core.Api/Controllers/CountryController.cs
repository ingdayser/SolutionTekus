using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekus.Core.Application.DTO.Out;
using Tekus.Core.Application.Helpers;
using Tekus.Core.Application.ServicesContracts;

namespace Tekus.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryAppService _countryAppService;
        public CountryController(ICountryAppService countryAppService)
        {
            this._countryAppService = countryAppService;
        }

        // GET: Country
        [HttpGet]       
        public async Task<RequestResult<List<CountryDto>>> Index()
        {
            return await _countryAppService.GetAllAsync();
        }

        // GET: Country/Details/5
        [HttpGet]
        [Route (nameof(CountryController.Details))]
        public async Task<RequestResult<CountryDto>> Details(string id)
        {
            return await _countryAppService.GetByIdAsync(id);
        }

        //// GET: ServiceController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ServiceController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ServiceController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ServiceController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ServiceController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ServiceController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

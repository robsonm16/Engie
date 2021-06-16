using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commom;
using Domain.Dto;
using Domain.Filters;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngieWeb.Controllers
{

    public class UsinaController : Controller
    {

        private readonly IUsinaService _usinaService;
        public UsinaController(IUsinaService usinaService)
        {
            this._usinaService = usinaService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(UsinaFilter filter)
        {
            var result = await this._usinaService.GetByFilters(filter);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsinaDto dto)
        {
            try
            {
                await this._usinaService.Save(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await this._usinaService.Remove(new UsinaDto { UsinaId = id });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await this._usinaService.GetOne(new UsinaFilter { UsinaId = id });
            return View(result);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(UsinaDto dto)
        {
            try
            {
                await this._usinaService.SavePartial(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

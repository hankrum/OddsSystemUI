﻿using System.Collections.Generic;
using System.Linq;
using OddsSystemUI.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using OddsSystemUI.Models;
using OddsSystemUI.Data.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OddsSystemUI.Controllers
{
    public class SportEventController : Controller
    {
        private readonly IEventsService eventsService;

        public SportEventController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ViewAll");
        }

        public async Task<IActionResult> ViewAll()
        {
            IEnumerable<SportEvent> events = await this.eventsService.All();

            IEnumerable<EventViewModel> models = events.Select<SportEvent, EventViewModel>(x => new EventViewModel(x));
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> EditAll()
        {
            IEnumerable<SportEvent> events = await this.eventsService.All();
            IEnumerable<EventViewModel> models = events.Select<SportEvent, EventViewModel>(x => new EventViewModel(x));

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> EditAll(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != null && model.Id > 0)
                {
                    this.eventsService.Edit(model.ToDataModel());
                }
                else
                {
                    this.eventsService.Add(model.ToDataModel());
                }
                return RedirectToAction("EditAll", "SportEvent");
            }
            else
            {
                IEnumerable<SportEvent> events = await this.eventsService.All();
                IEnumerable<EventViewModel> models = events.Select<SportEvent, EventViewModel>(x => new EventViewModel(x));

                return View(models);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EventViewModel model)
        {
            this.eventsService.Delete(model.ToDataModel());

            return RedirectToAction("EditAll", "SportEvent");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using OddsSystemUI.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using OddsSystemUI.Models;
using OddsSystemUI.Data.Models;
using System.Threading.Tasks;

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
            return RedirectToAction("Events");
        }

        public async Task<IActionResult> Events()
        {
            IEnumerable<SportEvent> events = await this.eventsService.All();

            IEnumerable<EventViewModel> models = events.Select<SportEvent, EventViewModel>(x => new EventViewModel(x));
            return View(models);
        }
    }
}
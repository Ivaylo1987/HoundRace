namespace HoundRace.Web.Controllers
{
    using HoundRace.Services;
    using HoundRace.Services.Contracts;
    using HoundRace.Web.ViewModels;

    using System;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private IRaceEventService raceEventService;

        // Poor man's IoC. Only use it in case there is no dependancy injector.
        public HomeController()
            : this(new RaceEventService())
        {
        }

        public HomeController(IRaceEventService raceEventService)
        {
            this.raceEventService = raceEventService;
        }

        public ActionResult Index()
        {
            var raceEvents = this.GetRaceEvents();

            return View(raceEvents);
        }

        public ActionResult RefreshRaceEvents(int eventNumber)
        {
            var raceEvent = this.GetRaceEvents().FirstOrDefault(r => r.EventNumber == eventNumber);

            if (Request.QueryString["byName"] != null)
            {
                var nameValue = Request.QueryString["byName"];
                raceEvent = this.OrderByValue(e => e.Name, nameValue, raceEvent);
            }

            if (Request.QueryString["byOdds"] != null)
            {
                var oddsValue = Request.QueryString["byOdds"];
                raceEvent = this.OrderByValue(e => e.OddsDecimal, oddsValue, raceEvent);
            }

            return this.PartialView("RaceEventPartial", raceEvent);
        }

        private IEnumerable<RaceEventViewModel> GetRaceEvents()
        {
            var filePath = this.Server.MapPath("~/App_Data/race.xml");
            var raceEvents = this.raceEventService.GetRaceEvents(filePath).Select(RaceEventViewModel.FromRaceEvent).ToArray();

            for (int i = 0; i < raceEvents.Count(); i++)
            {
                raceEvents[i].Entries = raceEvents[i].Entries.OrderBy(e => e.Name);
            }

            return raceEvents;
        }

        private RaceEventViewModel OrderByValue<T>(Func<EntryViewModel, T> orderExpression, string value, RaceEventViewModel raceEvent)
        {
            if (value == "Ascending")
            {
                raceEvent.Entries = raceEvent.Entries.OrderBy(orderExpression);
            }
            else
            {
                raceEvent.Entries = raceEvent.Entries.OrderByDescending(orderExpression);
            }

            return raceEvent;
        }
    }
}
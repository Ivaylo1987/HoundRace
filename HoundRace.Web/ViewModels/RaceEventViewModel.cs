namespace HoundRace.Web.ViewModels
{
    using HoundRace.Models;

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RaceEventViewModel
    {
        public static Func<RaceEvent, RaceEventViewModel> FromRaceEvent
        {
            get
            {
                return raceEvent => new RaceEventViewModel()
                {
                    EventNumber = raceEvent.EventNumber,
                    EventTime = raceEvent.EventTime,
                    FinishTime = raceEvent.FinishTime,
                    Distance = raceEvent.Distance,
                    Name = raceEvent.Name,
                    Entries = raceEvent.Entries.Select(EntryViewModel.FromEntry)
                };
            }
        }

        public int EventNumber { get; set; }

        public DateTime EventTime { get; set; }

        public DateTime FinishTime { get; set; }

        public int Distance { get; set; }

        public string Name { get; set; }

        public IEnumerable<EntryViewModel> Entries { get; set; }
    }
}
namespace HoundRace.Services
{
    using HoundRace.Models;
    using HoundRace.Parsers;
    using HoundRace.Parsers.Contracts;
    using HoundRace.Services.Contracts;

    using System;
    using System.Collections.Generic;
    public class RaceEventService : IRaceEventService
    {
        private IParser parser;

        // Poor man's IoC. Only use it in case there is no dependancy  injector.
        public RaceEventService()
            : this(new XMLRaceEventParser())
        {
        }

        public RaceEventService(IParser parser)
        {
            this.parser = parser;
        }

        public IEnumerable<RaceEvent> GetRaceEvents(string fileName)
        {
            IEnumerable<RaceEvent> raceEvents = new List<RaceEvent>();

            try
            {
                raceEvents = this.parser.ParseFile(fileName);
            }
            catch (FormatException)
            {
                // Handle parsing exceptions accordingly.
            }

            return raceEvents;
        }
    }
}

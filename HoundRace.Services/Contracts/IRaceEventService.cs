namespace HoundRace.Services.Contracts
{
    using HoundRace.Models;
    using System.Collections.Generic;
    public interface IRaceEventService
    {
        IEnumerable<RaceEvent> GetRaceEvents(string fileName);
    }
}

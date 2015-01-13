namespace HoundRace.Parsers.Contracts
{
    using HoundRace.Models;
    using System.Collections.Generic;
    public interface IParser
    {
        IEnumerable<RaceEvent> ParseFile(string fileName);
    }
}
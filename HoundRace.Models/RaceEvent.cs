namespace HoundRace.Models
{
    using System;
    using System.Collections.Generic;
    public class RaceEvent
    {
        public int Id { get; set; }

        public int EventNumber { get; set; }

        public DateTime EventTime { get; set; }

        public DateTime  FinishTime { get; set; }

        public int Distance { get; set; }

        public string Name { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}

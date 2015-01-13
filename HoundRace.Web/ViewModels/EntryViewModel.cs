namespace HoundRace.Web.ViewModels
{
    using HoundRace.Models;
    using System;
    public class EntryViewModel
    {
        public static Func<Entry, EntryViewModel> FromEntry
        { 
            get
            {
                return entry => new EntryViewModel()
                {
                    Name = entry.Name,
                    OddsDecimal = entry.OddsDecimal
                };
            }
        }

        public string Name { get; set; }

        public decimal OddsDecimal { get; set; }
    }
}
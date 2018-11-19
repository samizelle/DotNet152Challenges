using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Outing
    {
        public string OutingType { get; set; }
        public int NumberOfAttendees { get; set; }
        public string DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalEventCost { get; set; }

        public Outing() { }

        public Outing(string outingType, int numberOfAttendees, string dateOfEvent, decimal costPerPerson, decimal totalEventCost)
        {
            OutingType = outingType;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            TotalEventCost = totalEventCost;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _outingList = new List<Outing>();

        public List<Outing> GetOutings()
        {
            return _outingList;
        }

        public void AddOutingToList(Outing outing)
        {
            _outingList.Add(outing);
        }

        public decimal TotalEventCost(decimal costPerPerson, decimal totalEventCost)
        {
            var total = costPerPerson * totalEventCost;
            return total;
        }

        public int ParseResponseToInt()
        {
            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            return input;
        }

        public decimal ParseResponseToDecimal()
        {
            string inputAsString = Console.ReadLine();
            decimal decimalInput = decimal.Parse(inputAsString);
            return decimalInput;
        }
    }
}

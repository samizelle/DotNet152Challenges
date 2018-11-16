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
        /*
        public decimal CalculateTotalCombinedEventCost()
        {
            decimal totalCost = 0.00m;
            foreach (Outing outing in _outingList)
            {
                totalCost += outing.TotalEventCost;
            }
            return totalCost;
        }*/

        /*public decimal CalculateTotalCostsGolf()
        {
            decimal totalCostGolf = 0.00m;
            foreach (Outing outing in _outingList)
            {
                if (outing.OutingType == "Golf")
                {
                    totalCostGolf += outing.TotalEventCost;
                }
                return totalCostGolf;
            }
        }*/

        /*            decimal totalCostBowling = 0.00m;
            decimal totalCostAmusementPark = 0.00m;
            decimal totalCostConcert = 0.00m;


                else if (outing.OutingType == "Bowling")
                {
                    totalCostBowling += outing.TotalEventCost;
                }
                else if (outing.OutingType == "AmusementPark")
                {
                    totalCostAmusementPark += outing.TotalEventCost;
                }
                else if (outing.OutingType == "Concert")
                {
                    totalCostConcert += outing.TotalEventCost;
                }*/

    }
}

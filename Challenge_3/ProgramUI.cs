using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository outingRepo = new OutingRepository();
        List<Outing> _outingList;

        public void Run()
        {
            _outingList = outingRepo.GetOutings();
            Outing outingOne = new Outing("Golf", 24, "5/25/2018", 25.00m, 600.00m);
            Outing outingTwo = new Outing("Bowling", 16, "3/15/2018", 15.00m, 240.00m);
            Outing outingThree = new Outing("Amusement Park", 57, "7/15/2018", 24.00m, 1368.00m);
            Outing outingFour = new Outing("Golf", 36, "7/29/2018", 35.00m, 1260.00m);
            Outing outingFive = new Outing("Concert", 45, "9/13/2018", 37.00m, 1665.00m);
            Outing outingSix = new Outing("Bowling", 20, "8/15/2018", 15.00m, 300.00m);

            outingRepo.AddOutingToList(outingOne);
            outingRepo.AddOutingToList(outingTwo);
            outingRepo.AddOutingToList(outingThree);
            outingRepo.AddOutingToList(outingFour);
            outingRepo.AddOutingToList(outingFive);
            outingRepo.AddOutingToList(outingSix);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n\t" +
                    "1 Add an Event\n\t" +
                    "2 Print a List of All Events\n\t" +
                    "3 View Total Costs by Event Type\n\t" +
                    "4 View Total Costs\n\t" +
                    "5 Exit");
                int input = ParseResponseToInt();

                switch (input)
                {
                    case 1:
                        AddOutingToList();
                        isRunning = true;
                        break;
                    case 2:
                        PrintOutingListString();
                        isRunning = true;
                        break;
                    case 3:
                        CalculateTotalCostsByEvent();
                        isRunning = true;
                        break;
                    case 4:
                        CalculateTotalCombinedEventCost();
                        isRunning = true;
                        break;
                    case 5:
                        Console.WriteLine("Thank you!");
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddOutingToList()
        {
            string outingType;

            Console.WriteLine("What type of event are you creating?" +
                "\n1. Golf" +
                "\n2. Bowling" +
                "\n3. Amusement Park" +
                "\n4. Concert");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    outingType = "Golf";
                    break;
                case "2":
                    outingType = "Bowling";
                    break;
                case "3":
                    outingType = "Amusement Park";
                    break;
                default:
                    outingType = "Concert";
                    break;
            }
            Console.WriteLine("How many people attended this event?");
            int numberOfAttendees = ParseResponseToInt();
            Console.WriteLine("What was the date of the event?");
            string dateOfEvent = Console.ReadLine();
            Console.WriteLine("What was the cost per person? (0.00)");
            decimal costPerPerson = ParseResponseToDecimal();
            decimal totalEventCost = costPerPerson * numberOfAttendees;
            Outing newOuting = new Outing(outingType, numberOfAttendees, dateOfEvent, costPerPerson,
                totalEventCost);
            outingRepo.AddOutingToList(newOuting);
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
        public void PrintOutingListString()
        {
            foreach (Outing outing in _outingList)
            {
                Console.WriteLine($"{outing.OutingType,-15} {outing.DateOfEvent,10} " +
                    $"{outing.NumberOfAttendees,2} attendees, ${outing.CostPerPerson,6} " +
                    $"per person, ${outing.TotalEventCost,10} Total Cost");
            }
        }

        public void CalculateTotalCostsByEvent()
        {
            decimal totalCostGolf = 0.00m;
            decimal totalCostBowling = 0.00m;
            decimal totalCostAmusementPark = 0.00m;
            decimal totalCostConcert = 0.00m;

            foreach (Outing outing in _outingList)
            {
                if (outing.OutingType == "Golf")
                {
                    totalCostGolf += outing.TotalEventCost;
                }
                else if (outing.OutingType == "Bowling")
                {
                    totalCostBowling += outing.TotalEventCost;
                }
                else if (outing.OutingType == "Amusement Park")
                {
                    totalCostAmusementPark += outing.TotalEventCost;
                }
                else  // defaulting to Outing Type Concert 
                {
                    totalCostConcert += outing.TotalEventCost;
                }
            }

            Console.WriteLine($"Total costs are broken down as follows:\n\t" +
                "Total Costs for Golf Outings: {0}\n\t" +
                "Total Costs for Bowling Outings: {1}\n\t" +
                "Total Costs for Amusement Park Outings: {2}\n\t" +
                "Total Costs for Concert Outings: {3}\n\t", totalCostGolf, totalCostBowling,
                totalCostAmusementPark, totalCostConcert);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }

        public void CalculateTotalCombinedEventCost()
        {
            decimal totalCost = 0.00m;
            foreach (Outing outing in _outingList)
            {
                totalCost += outing.TotalEventCost;
            }
            Console.WriteLine($"Total cost for all events is ${totalCost}\n\t");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadLine();
        }
    }
}

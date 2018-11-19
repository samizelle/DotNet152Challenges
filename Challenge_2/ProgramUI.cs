using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ProgramUI
    {
        ClaimRepository claimRepo = new ClaimRepository();
        Queue<Claim> claims;
        public void Run()
        {
            claims = claimRepo.GetClaims();
            Claim claimOne = new Claim()
            {
                ClaimID = 1,
                ClaimType = "auto",
                Description = "Car accident on 465",
                ClaimAmount = 400.00m,
                DateOfIncident = "4/25/2018",
                DateOfClaim = "4/27/2018",
                IsValid = true
            };
            Claim claimTwo = new Claim()
            {
                ClaimID = 2,
                ClaimType = "home",
                Description = "House fire in kitchen",
                ClaimAmount = 4000.00m,
                DateOfIncident = "4/26/2018",
                DateOfClaim = "4/28/2018",
                IsValid = true
            };
            Claim claimThree = new Claim() 
            {
                ClaimID = 3,
                ClaimType = "theft",
                Description = "Theft of pancakes",
                ClaimAmount = 4.00m,
                DateOfIncident = "4/27/2018",
                DateOfClaim = "6/1/2018",
                IsValid = false
            };

            claimRepo.AddClaimToQueue(claimOne);
            claimRepo.AddClaimToQueue(claimTwo);
            claimRepo.AddClaimToQueue(claimThree);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Process next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        PrintClaimList();
                        break;
                    case 2:
                        ProcessNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        Console.WriteLine("Thank you");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect response type");
                        break;
                }
            }
        }

        public void PrintClaimList()
        {
            Console.WriteLine("Here is your list of pending claims:");
            foreach (Claim claim in claimRepo.GetClaims())
            {
                Console.WriteLine($"{claim.ClaimID, -2} {claim.ClaimType, -5} " +
                    $"{claim.Description, -24} {claim.ClaimAmount, 10} " +
                    $"{claim.DateOfIncident, 10} {claim.DateOfClaim, 10} {claim.IsValid}");
            }
        }

        public void ProcessNextClaim()
        {
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Claim claim = claims.Peek();
            Console.WriteLine($"{claim.ClaimID}\n{claim.ClaimType}\n{claim.Description}" +
                $"\n{claim.ClaimAmount}\n{claim.DateOfIncident}\n{claim.DateOfClaim}" +
                $"\n{claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine().ToLower();

            bool readyToProcess = true;
            switch (input)
            {
                case "y":
                    readyToProcess = true;
                    claimRepo.GetClaims().Dequeue();
                    break;
                case "n":
                    readyToProcess = false;
                    break;
            }
        }

        public void EnterNewClaim()
        {
            Console.WriteLine("Entering a new claim:\n" +
                "Enter ClaimID:");
            int claimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Claim Type (auto/home/theft):");
            string claimType = Console.ReadLine();
            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter claim amount:");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Incident (mm/dd/yyyy)");
            string dateOfIncident = Console.ReadLine();
            Console.WriteLine("Enter Date of Claim (mm/dd/yyyy)");
            string dateOfClaim = Console.ReadLine();
            Console.WriteLine("Is the date of the claim within the 30-day claim window? y/n");
            string input = Console.ReadLine().ToLower();

            bool isValid = true;
            switch (input)
            {
                case "y":
                    isValid = true;
                    break;
                case "n":
                    isValid = false;
                    break;
                default:
                    Console.WriteLine("Invalid response");
                    break;
            }
            Claim newClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);

            claimRepo.AddClaimToQueue(newClaim);
        }
    }
}
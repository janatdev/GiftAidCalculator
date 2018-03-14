using System;
using GiftAidCalculator.TestConsole.BuisnessLayer;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal taxRate = 0;
            decimal donationAmount = 0;
            int eventCode=0;

            ITaxRateSetting setRate = new TaxRateSetting();

            Console.WriteLine("\n\t\tPlease enter the tax rate:");
            if (decimal.TryParse(Console.ReadLine(), out taxRate))
            {
                setRate.SetTaxRate = taxRate;

                Console.WriteLine("\n\t\t Please Enter donation amount:");
                if (decimal.TryParse(Console.ReadLine(), out donationAmount))
                {                    
                    var calculateTax = new TaxRateCalculator(setRate);

                    decimal giftAid = calculateTax.GiftAidCalculation(donationAmount);
                    Console.WriteLine("\n\t\t Gift aid calculated at the rate of " + taxRate + " is:" + decimal.Round(giftAid, 2) + "\n");

                    Console.WriteLine(
                        "\n Select Event Supplement Code: \n 1 - 5% supplement added for donations to Running events. \n 2 - 3% supplement added for donations to Swimming events. \n 3 - for other events.");

                    if (int.TryParse(Console.ReadLine(), out eventCode))
                    {                        
                        Console.WriteLine("\n The calculated gift amount is: "
                                          + (donationAmount + giftAid
                                             +decimal.Round(EventTypeCalculations.AddEventSupplement(eventCode, donationAmount),2))
                                             + "\n");

                        Console.WriteLine("Press any key to exit.");

                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid number entered. Please enter number in decimal format.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number entered. Please enter number in decimal format.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid number entered. Please enter number in decimal format.");
                Console.ReadLine();
            }
        }
    }
}
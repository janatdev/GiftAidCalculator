using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiftAidCalculator.TestConsole.EntityDataSource;

namespace GiftAidCalculator.TestConsole
{
    public class EventTypeCalculations
    {
        public static decimal AddEventSupplement(int eventCode, decimal donationAmount)
        {
            decimal result = 0;
            decimal eventSupplement = 0;
            
            switch (eventCode)
            {
                case (int)EventTypeEntities.Running:
                    eventSupplement = 5;
                    break;
                case (int)EventTypeEntities.Swimming:
                    eventSupplement = 3;
                    break;
                case (int)EventTypeEntities.Others:
                    eventSupplement = 0;
                    break;
            }
            result = donationAmount * (eventSupplement / 100);

            return result;
        }
    }
}

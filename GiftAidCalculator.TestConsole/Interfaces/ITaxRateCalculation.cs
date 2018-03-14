using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole.Interfaces
{
    public interface ITaxRateCalculation
    {
        decimal GiftAidCalculation(decimal donationAmount);
    }
}

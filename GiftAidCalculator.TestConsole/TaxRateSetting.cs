using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole
{
    public class TaxRateSetting : ITaxRateSetting
    {
        public decimal SetTaxRate { get; set; }
    }
}

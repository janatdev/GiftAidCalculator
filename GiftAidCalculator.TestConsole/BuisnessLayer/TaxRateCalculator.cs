using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GiftAidCalculator.TestConsole.Interfaces;

namespace GiftAidCalculator.TestConsole.BuisnessLayer
{
    public class TaxRateCalculator : ITaxRateCalculation
    {
        private readonly ITaxRateSetting _configRate;

        public TaxRateCalculator(ITaxRateSetting configRateSetting)
        {
            _configRate = configRateSetting;
        }

        public decimal GiftAidCalculation(decimal donationAmount)
        {
            var giftAidRatio = _configRate.SetTaxRate/(100);
            
            // *** This formula Calculates the 25% of donation amount
            //var giftAidRatio = _configRate.SetTaxRate / (100 - _configRate.SetTaxRate); 
            // var giftAidRatio = 17.5m / (100 - 17.5m);  *** This Calculates the 25% of donation amount.
            return donationAmount * giftAidRatio;
        }
    }
}
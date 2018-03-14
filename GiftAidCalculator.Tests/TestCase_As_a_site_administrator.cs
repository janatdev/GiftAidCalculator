using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.BuisnessLayer;
using GiftAidCalculator.TestConsole;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    class TestCase_as_a_site_administrator
    {
        [Test]
        public void Get_tax_rate()
        {
            //Arrange
            const decimal setCurrentTaxRate = 20m;
            const decimal expectedTaxRate = 20m;

            ITaxRateSetting setTaxRate = new TaxRateSetting();

            //Act
            setTaxRate.SetTaxRate = setCurrentTaxRate;
            decimal actualTaxRate = setTaxRate.SetTaxRate;

            //Assert
            Assert.AreEqual(actualTaxRate, expectedTaxRate);
            Console.WriteLine("Tax Rate is [" + actualTaxRate + " %].");
        }
    }
}

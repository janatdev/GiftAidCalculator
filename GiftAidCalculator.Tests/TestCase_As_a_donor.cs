using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using GiftAidCalculator.TestConsole;
using GiftAidCalculator.TestConsole.BuisnessLayer;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.EntityDataSource;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    class TestCase_As_a_donor
    {
        [Test]
        public void Giftaid_calculation_by_taxrate()
        {
            //Arrange
            const decimal taxRate = 20;
            const decimal donationAmount = 10;
            const decimal expectedResult = 2.0m;

            var mockConfigRepositry = new Mock<ITaxRateSetting>();
            mockConfigRepositry.Setup(x => x.SetTaxRate).Returns(taxRate);
            ITaxRateCalculation taxRateSetting = new TaxRateCalculator(mockConfigRepositry.Object);

            //Act
            decimal actualResult = taxRateSetting.GiftAidCalculation(donationAmount);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Console.WriteLine("Gift aid at a tax rate of " + taxRate + " is: " + actualResult);
        }

        [Test]
        public void Round_to_two_decimal()
        {
            //Arrange
            const decimal expectedValue = 12m;
            const decimal taxRate = 20m;
            const decimal donationAmount = 10m;

            var mockConfigRepositry = new Mock<ITaxRateSetting>();
            mockConfigRepositry.Setup(x => x.SetTaxRate).Returns(taxRate);
            ITaxRateCalculation taxRateSetting = new TaxRateCalculator(mockConfigRepositry.Object);

            decimal actual = taxRateSetting.GiftAidCalculation(donationAmount);

            //Act
            decimal actualValue = decimal.Round(donationAmount + actual, 2);

            //Assert
            Assert.AreEqual(actualValue, expectedValue);
            Console.WriteLine("Actual donation : [ " + donationAmount + " ] after adding gift aid and rounding to 2 decimal : " +
                              actualValue);
        }

    }
}

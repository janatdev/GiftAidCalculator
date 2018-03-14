using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using GiftAidCalculator.TestConsole.Interfaces;
using GiftAidCalculator.TestConsole.BuisnessLayer;
using GiftAidCalculator.TestConsole;
using GiftAidCalculator.TestConsole.EntityDataSource;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    class TestCase_As_an_events_promoter
    {
        [Test]
        public void Giftaid_calculation_by_running_supplement()
        {
            //Arrange
            const decimal taxRate = 20;
            const decimal donationAmount = 10;
            const decimal expectedResult = 12.50m;
            const int eventCode = 1;

            var mockConfigRepositry = new Mock<ITaxRateSetting>();
            mockConfigRepositry.Setup(x => x.SetTaxRate).Returns(taxRate);
            ITaxRateCalculation taxRateSetting = new TaxRateCalculator(mockConfigRepositry.Object);

            //Act
            decimal actualResult = taxRateSetting.GiftAidCalculation(donationAmount);
            decimal actual = donationAmount + actualResult + decimal.Round(EventTypeCalculations.AddEventSupplement(eventCode, donationAmount), 2);

            //Assert
            Assert.AreEqual(expectedResult, actual);
            Console.WriteLine(actual);
        }

        [Test]
        public void Giftaid_calculation_by_swiming_supplement()
        {
            //Arrange
            const decimal taxRate = 20;
            const decimal donationAmount = 10;
            const decimal expectedResult = 12.30m;
            const int eventCode = 2;

            var mockConfigRepositry = new Mock<ITaxRateSetting>();
            mockConfigRepositry.Setup(x => x.SetTaxRate).Returns(taxRate);
            ITaxRateCalculation taxRateSetting = new TaxRateCalculator(mockConfigRepositry.Object);

            //Act
            decimal actualResult = taxRateSetting.GiftAidCalculation(donationAmount);
            decimal actual = donationAmount + actualResult + decimal.Round(EventTypeCalculations.AddEventSupplement(eventCode, donationAmount), 2);

            //Assert
            Assert.AreEqual(expectedResult, actual);
            Console.WriteLine(actual);
        }

        [Test]
        public void Giftaid_calculation_by_nothing_supplement()
        {
            //Arrange
            const decimal taxRate = 20;
            const decimal donationAmount = 10;
            const decimal expectedResult = 12.00m;
            const int eventCode = 3;

            var mockConfigRepositry = new Mock<ITaxRateSetting>();
            mockConfigRepositry.Setup(x => x.SetTaxRate).Returns(taxRate);
            ITaxRateCalculation taxRateSetting = new TaxRateCalculator(mockConfigRepositry.Object);

            //Act
            decimal actualResult = taxRateSetting.GiftAidCalculation(donationAmount);
            decimal actual = donationAmount + actualResult +
                             decimal.Round(EventTypeCalculations.AddEventSupplement(eventCode, donationAmount), 2);

            //Assert
            Assert.AreEqual(expectedResult, actual);
            Console.WriteLine(actual);
        }
    }
}

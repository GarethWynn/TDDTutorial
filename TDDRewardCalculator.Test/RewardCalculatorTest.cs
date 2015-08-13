using Moq;
using NUnit.Framework;
using SalesRepository.Interfaces;
using SalesRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator.Test
{
    /// <summary>
    /// Test cases for the RewardCalculator class. 
    /// </summary>
    [TestFixture]
    public class RewardCalculatorTest
    {
        /// <summary>
        /// Test that CalculateRewards method throws ArgumentNullException when passed a null value.
        /// </summary>
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void CalculateRewards_NullRewardPeriod_Throws_NullArgumentException_Test()
        {
            // ARRANGE
            var calculator = new RewardCalculator(null);

            // ACTION
            calculator.CalculateRewards(null);
        }

        /// <summary>
        /// Test that ArgumentException is thrown when start date is not earlier than end date.
        /// </summary>
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void CalculateRewards_InvalidRewardPeriod_Throws_ArgumentException_Test()
        {
            // ARRANGE
            var calculator = new RewardCalculator(null);
            calculator.CalculateRewards(DateRange.Range(DateTime.Now.AddDays(1), DateTime.Now));
        }

        /// <summary>
        /// Test that ISalesRepository GetClaimsByDate method is called exactly once and with the correct date range.
        /// </summary>
        [Test]
        public void CalculateRewards_CallsRepositoryWithCorrectDateRange_Test()
        {
            // ARRANGE
            var mock = new Mock<ISalesRepository>();
            var period = DateRange.Quarter(2015, 3);
            var calculator = new RewardCalculator(mock.Object);

            // ACTION
            calculator.CalculateRewards(period);

            // ASSERT
            // See the Moq "Verify" method and "It" class. 
            mock.Verify(
                repo => repo.GetClaimsByDate(
                    It.Is<DateTime>(p1 => p1.Equals(period.StartDate)),
                    It.Is<DateTime>(p2 => p2.Equals(period.EndDate))), 
                    Times.Once(), "GetClaimsByDate not verified"
            );
        }

        /// <summary>
        /// Test that the CalculateRewards method returns the correct reward total for each claimant where each sales claim is worth £10. 
        /// </summary>
        [Test]
        public void CalculateRewards_RewardCalculation_Test()
        {
            // ARRANGE
            var mock = new Mock<ISalesRepository>();
            var calculator = new RewardCalculator(mock.Object);

            // test data
            // only define the minimum amount of data for this particular test case.
            var data = new List<SalesClaim>()
            {
                new SalesClaim() { ClaimantId = 1 },
                new SalesClaim() { ClaimantId = 2 },
                new SalesClaim() { ClaimantId = 2 }
            };

            // setup mock to return test data (see "Setup" method). 
            mock.Setup(repo => repo.GetClaimsByDate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(data);

            // define expected results
            var expected = new List<Reward>()
            {
                new Reward() { ClaimantId = 1, RewardValue = 10 },
                new Reward() { ClaimantId = 2, RewardValue = 20 },
            };

            // ACTION
            var result = calculator.CalculateRewards(DateRange.Unbounded());
            
            // ASSERT
            // test that actual results match the expected (see NUnit.CollectionAssert the RewardComparer class in this project).           
            CollectionAssert.AreEqual(expected, result, new RewardComparer(), "calculated awards do not match expected");            
        }               
    }
}

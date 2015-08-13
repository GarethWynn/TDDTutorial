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
            // 1. ARRANGE
            var calculator = new RewardCalculator(null);

            // 2. ACTION
            calculator.CalculateRewards(null);
        }

        /// <summary>
        /// Test that ArgumentException is thrown when start date is not earlier than end date.
        /// </summary>
        /*[Test]
        public void CalculateRewards_InvalidRewardPeriod_Throws_ArgumentException_Test()
        {
            // 1. ARRANGE
            // *** TODO ***
            
            // 2. ACTION 
            // *** TODO ***
        }*/

        /// <summary>
        /// Test that ISalesRepository GetClaimsByDate method is called exactly once and with the correct date range.
        /// </summary>
        /*[Test]
        public void CalculateRewards_CallsRepositoryWithCorrectDateRange_Test()
        {
            // ARRANGE
            var mock = new Mock<ISalesRepository>();
            var period = DateRange.Unbounded();
            var calculator = new RewardCalculator(mock.Object);

            // ACTION
            calculator.CalculateRewards(period);

            // ASSERT
            // Test that ISalesRepository GetClaimsByDate method is called exactly once and with the correct date range
            // See the Moq "Verify" method and "It" class. 
            // *** TODO ***
            
            throw new NotImplementedException();
        }*/

        /// <summary>
        /// Test that the CalculateRewards method returns the correct reward total for each claimant where each sales claim is worth £10. 
        /// </summary>
        /*[Test]
        public void CalculateRewards_RewardCalculation_Test()
        {
            // ARRANGE
            // *** TODO ***

            // create test data
            // tip: only define the minimum amount of data for this particular test case.
            // *** TODO ***

            // setup mock to return test data (see "Setup" method It.IsAny() and "Returns"). 
            // hint: The previous test method should already check that GetClaimsByDate is called correctly.
            // Don't test that again here, just return the data. 
            // *** TODO ***
            
            // define expected results
            // *** TODO ***

            // ACTION
            // *** TODO ***
            
            // ASSERT
            // test that actual results match the expected 

            // big tip: NUnit includes the handy CollectionAssert.AreEqual method for comparing collections. 
            // Because our Reward class doesn't override the Equals method, CollectionAssert.AreEqual will use reference equality. 
            // This will fail because our expected and actual results are different references. 
            // Therefore, we need to use an override of AreEqual that can take an IComparer implementation 
            // (see RewardComparer class in this project).            
            // An alternative solution would be for Reward to override Equals and GetHashCode methods.  

            // *** TODO ***
        }*/       

        /// <summary>
        /// Test that the CalculateRewards method returns the correct reward total for each claimant in Q4. 
        /// </summary>
        /*[Test]
        public void CalculateRewards_RewardCalculation_Q4Bonus_Test()
        {
            // There is a new requirement. 
            // In Q4 of 2015 only, a bonus award is given when a claimant claims sales above a set target. 
            // Sales up to the target are still awarded £10 each, but any sales over the target are paid at
            // a rate of £20 each. The target is fixed at 5 sales in the quarter. 

            // tip: Write the test initially so that it fails (red). 
            // Write a simple solution to get the test to pass (green). 
            // Now that the test passes, re-factor if possible. 

            // *** TODO ***
        }*/
    }
}

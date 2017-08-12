using SalesRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator
{
    /// <summary>
    /// Calculates rewards for sales claimants.
    /// </summary>
    public class RewardCalculator
    {
        ISalesRepository _salesRepository;
        
        public RewardCalculator(ISalesRepository salesRepository)
        {
            this._salesRepository = salesRepository;
        }

        /// <summary>
        /// Calculate rewards for a particular data range.
        /// </summary>
        /// <returns>An enumeration of the calculated rewards.</returns>
        /// <param name="period">The time period to which the rewards relate.</param>
        public IEnumerable<Reward> CalculateRewards(DateRange period)
        {
            if(period == null)
            {
                throw new ArgumentNullException(nameof(period));
            }

            // TODO: reward calculation (see unit test project for specification). 

            return null;
        }
    }
}

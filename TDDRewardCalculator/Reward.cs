using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator
{
    /// <summary>
    /// A sales reward.
    /// </summary>
    public class Reward
    {
        /// <summary>
        /// The ID of the individual who has made the sales.
        /// </summary>
        /// <value>The claimant identifier.</value>
        public int ClaimantId { get; set; }

        /// <summary>
        /// The value of the reward.
        /// </summary>
        /// <value>The reward value.</value>
        public decimal RewardValue { get; set; }
    }
}

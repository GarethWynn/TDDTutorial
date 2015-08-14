using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator.Test
{
    class RewardComparer : IComparer<Reward>, IComparer
    {
        public int Compare(Reward x, Reward y)
        {
            return (x.RewardValue == y.RewardValue && x.ClaimantId == y.ClaimantId) ? 0 : 1;            
        }

        public int Compare(object x, object y)
        {
            Reward rewardX = x as Reward;
            Reward rewardY = x as Reward;

            if(rewardX == null || rewardY == null)
            {
                return 1;
            }

            return Compare(rewardX, rewardY);
        }
    }
}

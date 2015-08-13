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
            return Compare((Reward)x, (Reward)y);
        }
    }
}

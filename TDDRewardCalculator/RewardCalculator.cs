using SalesRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator
{
    public class RewardCalculator
    {
        ISalesRepository _salesRepository;
        
        public RewardCalculator(ISalesRepository salesRepository)
        {
            this._salesRepository = salesRepository;
        }

        public IEnumerable<Reward> CalculateRewards(DateRange period)
        {
            if(period == null)
            {
                throw new ArgumentNullException("period");
            }

            if (period.EndDate < period.StartDate)
            {
                throw new ArgumentException("endDate cannot be earlier than startDate");
            }

            decimal rewardValue = 10;

            var claims =  _salesRepository.GetClaimsByDate(period.StartDate, period.EndDate);

            return claims
                .GroupBy(x => x.ClaimantId)
                .Select(x1 =>
                    new Reward()
                    {
                        ClaimantId = x1.First().ClaimantId,
                        RewardValue = x1.Count() * rewardValue
                    }
            );
        }
    }
}

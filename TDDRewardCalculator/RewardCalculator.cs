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

            // TODO: reward calculation (see unit test project for specification). 

            return null;
        }
    }
}

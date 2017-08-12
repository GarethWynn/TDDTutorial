using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRewardCalculator
{
    public class DateRange
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private DateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool Contains(DateTime date)
        {
            return StartDate <= date && EndDate > date;
        }

        public bool Contains(DateRange range)
        {
            return Contains(range.StartDate) && Contains(range.EndDate);
        }

        public static DateRange Range(DateTime startDate, DateTime endDate)
        {
            return new DateRange(startDate, endDate);
        }

        public static DateRange Unbounded()
        {
            return new DateRange(DateTime.MinValue, DateTime.MaxValue);
        }

        public static DateRange Quarter(int year, int quarter)
        {
            if(quarter < 1 || quarter > 4)
            {
                throw new ArgumentOutOfRangeException(nameof(quarter));
            }

            int month = (quarter * 3) - 2;
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(3);

            return Range(start, end);
        }
    }
}

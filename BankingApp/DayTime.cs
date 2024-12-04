using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    using System;

    public struct DayTime
    {
        private long minutes;

        public DayTime(long minutes)
        {
            this.minutes = minutes;
        }

        public static DayTime operator +(DayTime lhs, int additionalMinutes)
        {
            return new DayTime(lhs.minutes + additionalMinutes);
        }

        public override string ToString()
        {
            long totalMinutes = minutes;
            int years = (int)(totalMinutes / 518_400);
            totalMinutes %= 518_400;
            int months = (int)(totalMinutes / 43_200);
            totalMinutes %= 43_200;
            int days = (int)(totalMinutes / 1_440);
            totalMinutes %= 1_440;
            int hours = (int)(totalMinutes / 60);
            int mins = (int)(totalMinutes % 60);

            return $"{years:D4}-{months + 1:D2}-{days + 1:D2} {hours:D2}:{mins:D2}";
        }
    }
}
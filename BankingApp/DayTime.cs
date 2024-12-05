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
        public DayTime(long minutes) => this.minutes = minutes;

        public override string ToString()
        {
            long minutes_in_year = 12 * 30 * 24 * 60;
            long minutes_in_month = 30 * 24 * 60;
            long minutes_in_day = 24 * 60;
            long minutes_in_hour = 60;

            long years = minutes / minutes_in_year;
            long remaining = minutes % minutes_in_year;
            long months = remaining / minutes_in_month;
            remaining %= minutes_in_month;
            long days = remaining / minutes_in_day;
            remaining %= minutes_in_day;
            long hours = remaining / minutes_in_hour;
            long mins = remaining % minutes_in_hour;

            return $"{years + 2023}/{months + 1}/{days + 1} {hours:D2}:{mins:D2}";
        }
    }
}
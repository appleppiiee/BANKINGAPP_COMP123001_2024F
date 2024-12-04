using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class Utils
    {
        const int HOUR = 60;
        const int DAY = HOUR * 24;
        const int MONTH = DAY * 30;
        const int YEAR = MONTH * 12;

        //starting time is September 3, 2024 @ 09:35hrs -> 2024/11/1 09:35
        static long CURRENT_TIME = 35 + 9 * HOUR + 2 * DAY + 8 * MONTH + 1 * YEAR;
        static Random rand = new Random(54321);
        public static DayTime Now
        {
            get
            {
                CURRENT_TIME += rand.Next(100);
                return new DayTime(CURRENT_TIME);
            }
        }
    }
}

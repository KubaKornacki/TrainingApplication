using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.ViewModel
{
    public class ViewHistoryViewModel
    {
        public List<DateTime> DateTimes { get; set; }
        public int SubtrainingId { get; set; }


        public ViewHistoryViewModel(List<DateTime> dateTimes,int id)
        {
            DateTimes = new List<DateTime>();
            DateTimes.AddRange(dateTimes);
            SubtrainingId = id;
        }
    }
}

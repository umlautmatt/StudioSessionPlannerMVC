using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionPlanner.Models.SessionType
{
    public class SessionTypeDetail
    {
        public int SessionTypeID { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
    }
}

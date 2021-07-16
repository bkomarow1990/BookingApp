using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFraemworkLesson2
{
    class RoomBinding
    {
        public string City { get; set; } = "Area";
        public float AreaFrom { get; set; } = 30;
        public float AreaTo { get; set; } = 200;
        public DateTime DateFrom { get; set; } = DateTime.Now;
        public DateTime DateTo { get; set; } = DateTime.Now.AddDays(1);
    }
}

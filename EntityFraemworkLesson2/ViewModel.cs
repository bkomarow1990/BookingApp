using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFraemworkLesson2
{
    internal class ViewModel
    {
        public Booking_GnidezEntities context;
        public Rents Rent = new Rents {
            IsAvailable = true,
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now.AddDays(1),
            
        };
        public RoomBinding Room { get; set; } = new RoomBinding();

        //public bool IsAvailable { get; set; }
        //public System.DateTime DateFrom { get; set; }
        //public System.DateTime DateTo { get; set; }
        //public int UserId { get; set; }
        //public int RoomId { get; set; }

        //public virtual Room Room { get; set; }
        //public virtual User User { get; set; }
        public ViewModel()
        {
            context = new Booking_GnidezEntities();
        }
        public static User logined_user { get; set; }


    }
}

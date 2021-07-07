using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFraemworkLesson2
{
    internal class ViewModel
    {
        public Booking_GnidezEntities context = new Booking_GnidezEntities();
        public User logined_user { get; set; }


    }
}

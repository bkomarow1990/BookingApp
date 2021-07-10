using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFraemworkLesson2
{
    internal class ContextMethods
    {
        Booking_GnidezEntities context = null;
        public ContextMethods(Booking_GnidezEntities context)
        {
            this.context = context;
        }
        
    }
}

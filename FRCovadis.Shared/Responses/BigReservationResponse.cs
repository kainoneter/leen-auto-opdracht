using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRCovadis.Responses
{
    public class BigReservationResponse
    {
        public int Id {  get; set; }
        public int AutoId { get; set; }
        public string AutoName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}

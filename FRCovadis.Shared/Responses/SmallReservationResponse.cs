using FRCovadis.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRCovadis.Responses
{
    public class SmallReservationResponse : BaseResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}

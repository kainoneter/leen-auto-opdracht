﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRCovadis.Responses
{
    public class ReservationResponse
    {
        public int Id {  get; set; }
        public int AutoId { get; set; }
        public int UserId { get; set; }

        public DateTime Start {  get; set; }

        public DateTime End { get; set; }   

    }
}

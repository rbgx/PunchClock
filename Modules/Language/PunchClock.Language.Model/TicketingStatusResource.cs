﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchClock.Language.Model
{
   public class TicketingStatusResource : BaseResource
    {
        [Index("UniqueResourceTicketingTypeCulture", 1)]
        public int StatusMasterId { get; set; }
        [Index("UniqueResourceTicketingTypeCulture", 2)]
        public Culture Culture { get; set; }
    }

}

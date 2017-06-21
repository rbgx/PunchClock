﻿using PunchClock.Core.Models.Common;

namespace PunchClock.Ticketing.Model
{
   public class TicketCategory: CommonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PunchClock.Domain.Model
{
    public  class ChangeLog
    {
        [Key]
        public long Id { get; set; }
        public string EntityName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanged { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string NotificationTyp { get; set; }
        public string NotificationTypSymbol { get; set; }
        public string NotificationDetils { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
        public string  NotificationColor { get; set; }
    }
}

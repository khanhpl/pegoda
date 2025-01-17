﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class ResponseOrderItemModel
    {
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid OrderId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid StaffId { get; set; }
    }
}

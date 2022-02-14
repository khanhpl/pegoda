﻿using System;
namespace Api.Modals
{
    public class ResponseServiceModal
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Duration { get; set; }
        public Guid CenterId { get; set; }
        public Guid AnimalId { get; set; }
        
    }
}
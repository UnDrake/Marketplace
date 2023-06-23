﻿namespace Marketplace.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
        public Sale Sale { get; set; }
    }
}
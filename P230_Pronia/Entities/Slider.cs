﻿namespace P230_Pronia.Entities
{
    public class Slider:BaseEntity
    {
        public string ImagePath { get; set; }
        public string PlantName { get; set; }
        public byte Discount { get; set; }
        public string Desc { get; set; }
        public string LeftIcon { get; set; }
        public string RightIcon { get; set; }
        public byte Order { get; set; }
    }
}

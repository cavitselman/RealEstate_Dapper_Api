﻿namespace RED.Api.DTOs.PropertyDTOs
{
    public class ResultPropertyWithCategoryDTO
    {
        public int PropertyID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string SlugUrl { get; set; }
        public bool DealOfTheDay  { get; set; }
        public bool PropertyStatus  { get; set; }
    }
}

﻿namespace RED.Api.DTOs.EmployeeDTOs
{
    public class GetByIDEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
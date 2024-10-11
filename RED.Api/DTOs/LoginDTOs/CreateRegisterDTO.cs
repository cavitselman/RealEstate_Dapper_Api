namespace RED.Api.DTOs.LoginDTOs
{
    public class CreateRegisterDTO
    {
        public string Username { get; set; }    
        public string Password { get; set; }     
        public string Email { get; set; }        
        public string Name { get; set; }         
        public string PhoneNumber { get; set; }  
        public string UserImageUrl { get; set; } 
        public int UserRole { get; set; } 
    }
}

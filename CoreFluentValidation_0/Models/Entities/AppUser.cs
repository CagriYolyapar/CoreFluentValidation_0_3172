namespace CoreFluentValidation_0.Models.Entities
{
    public class AppUser
    {
        public AppUser()
        {
            CreatedDate = DateTime.Now; 
        }
       
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}

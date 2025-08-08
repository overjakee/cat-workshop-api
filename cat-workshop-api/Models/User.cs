using System.ComponentModel.DataAnnotations;

namespace cat_workshop_api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = ""; 
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}

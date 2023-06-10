using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Login_Sign
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



        }
}

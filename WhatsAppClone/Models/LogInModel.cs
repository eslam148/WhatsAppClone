using System.ComponentModel.DataAnnotations;

namespace WhatsAppClone.Models
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

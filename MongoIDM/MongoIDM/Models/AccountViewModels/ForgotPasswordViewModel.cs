using System.ComponentModel.DataAnnotations;

namespace MongoIDM.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

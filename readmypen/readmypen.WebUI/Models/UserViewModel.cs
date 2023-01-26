using System.ComponentModel.DataAnnotations;

namespace readmypen.WebUI.Models
{
    public class UserViewModel
    {
        [Display(Name = "User Id")]
        public int usr_Id { get; set; }

        [Display(Name = "Username")]
        public string usr_Username { get; set; }

        [Display(Name = "Password")]
        public byte[] usr_Password { get; set; }

        [Display(Name = "Role Id")]
        public int rol_Id { get; set; }
    }
}

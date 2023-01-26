using System.ComponentModel.DataAnnotations;

namespace readmypen.WebUI.Models
{
    public class RoleViewModel
    {
        [Display(Name = "Role Id")]
        public int rol_Id { get; set; }


        [Display(Name = "Role Description")]
        public string rol_Description { get; set; }
    }
}

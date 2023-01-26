using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace readmypen.WebUI.Models
{
    public class PictureViewModel
    {
        [Display(Name = "Picture Id")]
        public int pic_Id { get; set; }

        [Display(Name = "Picture Path")]
        public string pic_PicturePath { get; set; }

        [Display(Name = "User Id")]
        public int usr_Id { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace readmypen.WebUI.Models
{
    public class PictureViewModel
    {
        public int pic_Id { get; set; }
        //public string pic_PictureName { get; set; }
        public IFormFile pic_PicturePath { get; set; }
        public int usr_Id { get; set; }

    }
}

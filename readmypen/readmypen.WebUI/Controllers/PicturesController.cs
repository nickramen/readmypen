using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using readmypen.DataAccess.Entities;
using readmypen.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using readmypen.DataAccess.Repositories;

namespace readmypen.WebUI.Controllers
{
    public class PicturesController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly AppDbContext _context;

        public PicturesController(IHostingEnvironment environment, AppDbContext context)
        {
            _environment = environment;
            _context = context;
        }


        //[HttpPost]
        //public IActionResult Upload(PictureViewModel model)
        //{
        //    // Validate the model
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    // Check if a file was uploaded
        //    if (model.pic_PicturePath == null || model.pic_PicturePath.Length == 0)
        //    {
        //        return BadRequest("File not found.");
        //    }

        //    // Save the file to the server
        //    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
        //    var filePath = Path.Combine(uploads, model.pic_PicturePath.FileName);
        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        model.pic_PicturePath.CopyTo(fileStream);
        //    }

        //    // Add the file information to the database
        //    var picture = new tbPictures
        //    {
        //        //pic_PictureName = model.pic_PictureName,
        //        pic_PicturePath = "/uploads/" + model.pic_PicturePath.FileName,
        //        usr_Id = model.usr_Id
        //    };
        //    //////_context.tbPictures.Add(picture);
        //    //////await _context.SaveChangesAsync();

        //    //////var repository = new PicturesRepository();
        //    //////repository.InsertPicture(picture);

        //    var repository = new PicturesRepository();
        //    repository.InsertPicture(picture.pic_PicturePath, picture.usr_Id);


        //    // Return the success status
        //    return Ok(new { status = "success", message = "File uploaded successfully." });

        //    ////return RedirectToAction(nameof(Index));
        //}

    }
}

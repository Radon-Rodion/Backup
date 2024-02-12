using FS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    [Route("/")]
    public class HomeController
    {
        private IWebHostEnvironment _hostEnvironment;
        public HomeController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(new MessageModel()
            {
                Specificator = 0,
                JsonContent = "{Hi}"
            });
        }

        [HttpPost("Upload")]
        public IActionResult Upload(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // saving to directory 'Files' in directory wwwroot
                string path = "/files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_hostEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                //await _filesProcessor.LoadFileToDbAsync(_hostEnvironment.WebRootPath + path, _context);
                return new RedirectResult("/here");
            }
            return new BadRequestObjectResult("No file attached!");
        }
    }
}

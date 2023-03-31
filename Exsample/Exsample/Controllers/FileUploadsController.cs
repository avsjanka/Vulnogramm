using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Exsample.ImageMethods;
using Exsample.Models;
namespace Exsample.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FileUploadsController : Controller
{
    // GET
    public static IWebHostEnvironment _webHostEnvironment;

    public FileUploadsController(IWebHostEnvironment environment)
    {
        _webHostEnvironment = environment;
    }

    [HttpPost]
    public string Post([FromForm] FileUploads file/*, string sign*/,int method)
    {
        try
        {
            if (file.file.Length > 0 )
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath+"uploads");
                }

                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath+"uploads/"+ file.file.FileName))
                {
                    file.file.CopyTo(fileStream);
                    Console.WriteLine($"{method}");
                    if (method == 1)
                    {
                        Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ file.file.FileName);
                        magick.Recoloring("qqqqq");
                    }
                    fileStream.Flush();
                    return "Uploaded";
                }
            }
            else
            {
                return "Not Uploaded.";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
   /* public IActionResult Index()
    {
        return View();
    }*/
}
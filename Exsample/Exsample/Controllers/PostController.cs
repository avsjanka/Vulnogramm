using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Exsample.ImageMethods;
using Exsample.Models;
namespace Exsample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController
{
    public static IWebHostEnvironment _webHostEnvironment;

    public PostController(IWebHostEnvironment environment)
    {
        _webHostEnvironment = environment;
    }

    [HttpPost]
    public string Post(NewPost newPost)
    {
        Console.WriteLine($"{newPost.method}");
        try
        {
            if (newPost.photo.Length > 0 )
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath+"uploads");
                }

                string type = "";
                if (newPost.photo.StartsWith("iVBORw0KGgo"))
                    type = ".png";
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type))
                {
                }
                if (newPost.method == 1)
                {
                    File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                    Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type);
                    magick.Recoloring(newPost.sign);
                }
                return "Uploaded";   
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
    
    
}
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Exsample.Data;
using Exsample.Models;
using Exsample.ImageMethods;
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
        Context context = new Context();
        newPost.photo = newPost.photo.Substring(newPost.photo.IndexOf(',')+1);
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
                if (newPost.method == 0)
                {
                    File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                }
                if (newPost.method == 1)
                {
                    File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                    Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type);
                    magick.Recoloring(newPost.sign);
                }
                if (newPost.method == 2)
                {
                    File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                }
                
                context.Post.Add(new Post
                {
                    Owner = newPost.Owner,
                    Subscript = newPost.subscript,
                    PhotoForOwner = newPost.photo,
                    PhotoForAll = newPost.photo,
                });
                context.SaveChanges();
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
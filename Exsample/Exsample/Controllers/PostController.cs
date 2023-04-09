using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Exsample.Data;
using Exsample.Models;
using Exsample.ImageMethods;
using System.Text.Json;
namespace Exsample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : Controller
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
                string for_all = "";
                if (newPost.photo.StartsWith("iVBORw0KGgo"))
                    type = ".png";
                if (newPost.method == 0)
                {
                    System.IO.File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                    Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type);
                    magick.TheLastofUS(newPost.sign);
                    newPost.photo = Convert.ToBase64String(System.IO.File.ReadAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type));
                    magick.Watermark(); 
                    for_all = Convert.ToBase64String(System.IO.File.ReadAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type));
                }
                if (newPost.method == 1)
                {
                    System.IO.File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                    Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type);
                    magick.Recoloring(newPost.sign);
                    magick.Watermark(); 
                    for_all = Convert.ToBase64String(System.IO.File.ReadAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type));
                }
                if (newPost.method == 2)
                {
                    System.IO.File.WriteAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+".png",Convert.FromBase64String(newPost.photo));
                    Magick magick = new Magick(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type);
                    magick.NewText(newPost.sign);
                    newPost.photo = Convert.ToBase64String(System.IO.File.ReadAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type));
                    magick.Watermark(); 
                    for_all = Convert.ToBase64String(System.IO.File.ReadAllBytes(_webHostEnvironment.WebRootPath+"uploads/"+ newPost.Owner+type));
                }
                
                context.Post.Add(new Post
                {
                    Owner = newPost.Owner,
                    Subscript = newPost.subscript,
                    PhotoForOwner = newPost.photo,
                    PhotoForAll = for_all,
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

    [HttpPost("/feed")]
    public IActionResult AddFeed()
    {
        Context context = new Context();
        var posts = context.Post.AsQueryable().ToList();
        return  Json(posts);
    }
}
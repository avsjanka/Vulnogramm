using ImageMagick;

namespace Exsample.Models;

public class Post
{
    public int Owner { get; set; }
    public int ID { get; set; }
    public string PhotoForOwner { get; set; }
    public string PhotoForAll { get; set; }
}
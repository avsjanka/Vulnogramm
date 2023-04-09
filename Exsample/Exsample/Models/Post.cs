using ImageMagick;

namespace Exsample.Models;
using Microsoft.EntityFrameworkCore;
[Index(nameof(Id), nameof(Owner), IsUnique = true)]

[Serializable]
public class Post
{
    public string Owner { get; set; }
    public int Id { get; set; }
    public string Subscript { get; set; }
    public string PhotoForOwner { get; set; }
    public string PhotoForAll { get; set; }
}
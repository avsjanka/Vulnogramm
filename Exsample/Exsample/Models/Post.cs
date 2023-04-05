using ImageMagick;

namespace Exsample.Models;
using Microsoft.EntityFrameworkCore;
[Index(nameof(ID), nameof(Owner), IsUnique = true)]

public class Post
{
    public uint Owner { get; set; }
    public uint ID { get; set; }
    public string Subscript { get; set; }
    public string PhotoForOwner { get; set; }
    public string PhotoForAll { get; set; }
}
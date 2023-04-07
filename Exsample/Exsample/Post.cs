using System;
using System.Collections.Generic;

namespace Exsample;

public partial class Post
{
    public int Id { get; set; }

    public string Owner { get; set; } = null!;

    public string Subscript { get; set; } = null!;

    public string PhotoForOwner { get; set; } = null!;

    public string PhotoForAll { get; set; } = null!;
}

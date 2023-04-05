namespace Exsample.Models;
using Microsoft.EntityFrameworkCore;

[Index(nameof(ID), nameof(Login), IsUnique = true)]

public class User
{
    public uint ID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
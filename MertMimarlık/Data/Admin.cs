using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertMimarlık.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertMimarlık.Data;
public class Admin
{
  
    [Key]
    public int AdminID { get; set; }

    [Required(ErrorMessage = "username alanı boş bırakılamaz.")]
    public string? username { get; set; }

    [Required(ErrorMessage = "şifre alanı boş bırakılamaz.")]
    public string? password { get; set; }   

     [Required(ErrorMessage = "şifre alanı boş bırakılamaz.")]
    public string? confirmpassword { get; set; }   

}
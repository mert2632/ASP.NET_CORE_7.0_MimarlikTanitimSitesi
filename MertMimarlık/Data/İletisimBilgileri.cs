using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertMimarlık.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertMimarlık.Data;
public class İletisimBilgileri
{
  
    [Key]
    public int IletisimID { get; set; }

    [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
    public string? AdSoyad { get; set; }

    [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Telefon Numarası alanı boş bırakılamaz.")]
    [RegularExpression(@"^0\d{10}$", ErrorMessage = "Geçersiz telefon numarası. Telefon numarası 0 ile başlamalı ve 11 haneli olmalıdır.")]
    public string? TelefonNumarasi { get; set; }

    [Required(ErrorMessage = "Konu alanı boş bırakılamaz.")]
    public string? Konu { get; set; }

    [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz.")]
    public string? Mesaj { get; set; }

}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertMimarlık.Models;
using MertMimarlık.Data;
namespace MertMimarlık.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly Context _context;
     public HomeController(Context context)
    {
        _context = context;
    }

    public IActionResult anasayfa()
    {
        return View();
    }

    public IActionResult hakkimizda()
    {
        return View();
    }
    public IActionResult bloglar()
    {
        return View();
    }
    public IActionResult projelerimiz()
    {
        return View();
    }
      public IActionResult iletisim()
    {
        return View();
    }
    //iletisim modelden parametre alıyoruz 
 [HttpPost]
public async Task<IActionResult> Iletisim(İletisimBilgileri model)
{
       
if (!ModelState.IsValid)
    {
        // Model doğrulaması başarısızsa, hata mesajları ile birlikte formu tekrar göster.
        return View("iletisim", model);
    }

    _context.iletisimBilgileris.Add(model);
    await _context.SaveChangesAsync();

    // Veriyi işleme (örneğin, veritabanına kaydetme) kodları buraya gelecek.
    // model.AdSoyad, model.Email, vb. şeklinde modele erişebilirsiniz.

    // İşlemin başarıyla gerçekleştiğini belirten bir mesaj verebilirsiniz.


    TempData["SuccessMessage"] = "İletişim bilgileriniz başarıyla alındı! Tekrar mesaj göndermek için alanları doldurabilirsiniz.";

    // Başka bir sayfaya yönlendirme örneği:
    return RedirectToAction("iletisim",model);
}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

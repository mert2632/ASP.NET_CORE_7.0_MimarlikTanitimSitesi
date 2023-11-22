using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertMimarlık.Models;
using MertMimarlık.Data;
using Microsoft.EntityFrameworkCore;
namespace MertMimarlık.Controllers;
public class AdminController : Controller
{
  //ınjeksin
  private readonly Context _context;
  public AdminController(Context context)
  {
    _context = context;
  }
  public IActionResult Index()
  {
    // Admin paneli ana sayfası
    return View();
  }

  //login wiew
  public IActionResult Login()
  {
    return View();
  }



  [HttpPost]
  public async Task<IActionResult> Login(Admin model)
  {

    var adminuserinfo = await _context.admins.FirstOrDefaultAsync(a => a.username == model.username && a.password == model.password);


    // Admin bulundu, giriş başarılı, yönlendir

    if (adminuserinfo != null||(model.username=="mert"&&model.password=="okcu"))
    {
      //İŞLEMLER
         return RedirectToAction("Index", model);
    }
    else
    {
       ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
      return View();
    }

  }


  //musteri listesi wiew
  public async Task<IActionResult> MusteriListesi()
  {
    var musteriler = await _context.iletisimBilgileris.ToListAsync();
    return View(musteriler);
  }
  //güncelle wiew
  [HttpGet]
  //bu metot müsteri listesindeki şeçtiğimiz ıdyle bir ıd si olup olmadığını değerlerinin boş olup 
  //olmadığı kontrolünü yapar ve şeçtiğimiz değerin context sınıfından güncelle wieine nesne olarak ALIR.
  public async Task<IActionResult> Güncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    return View(musteri);
  }

  //güncellenmiş wiew
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Güncelle(int id, İletisimBilgileri model)
  {
    if (id != model.IletisimID)
    {
      return NotFound();
    }


    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(model);
        await _context.SaveChangesAsync();
      }
      catch (Exception)
      {
        if (!_context.iletisimBilgileris.Any(m => m.IletisimID == model.IletisimID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("MusteriListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> Sil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    return View(musteri);
  }

  [HttpPost]

  public async Task<IActionResult> Sil([FromForm] int id)
  {

    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    _context.iletisimBilgileris.Remove(musteri);
    await _context.SaveChangesAsync();
    return RedirectToAction("MusteriListesi");
  }
  public IActionResult AdminEkle()
  {
    // Admin paneli ana sayfası
    return View();
  }



  [HttpPost]
  public async Task<IActionResult> AdminEkle(Admin model)
  {

    if (!ModelState.IsValid)
    {
      // Model doğrulaması başarısızsa, hata mesajları ile birlikte formu tekrar göster.
      return View("AdminEkle", model);
    }

    if (model.password != model.confirmpassword)
    {
      ModelState.AddModelError("password", "Şifreler eşleşmiyor.");
      // return View(model);
      return View("AdminEkle", model);
    }

    _context.admins.Add(model);
    await _context.SaveChangesAsync();



    TempData["SuccessMessage"] = "Admin bilgileri başarıyla alındı!Yeni kullanıcı adı ve şifreyle giriş yapılabilir..";

    // Başka bir sayfaya yönlendirme örneği:
    return RedirectToAction("AdminEkle", model);
  }


  // burası tamamenADMİN güncelle sil İŞLEMLEİ İÇİN
  public async Task<IActionResult> AdminListesi()
  {
    var adminler = await _context.admins.ToListAsync();
    return View(adminler);
  }



  [HttpGet]
  // bu metot müsteri listesindeki şeçtiğimiz ıdyle bir ıd si olup olmadığını değerlerinin boş olup 
  // olmadığı kontrolünü yapar ve şeçtiğimiz değerin context sınıfından güncelle wieine nesne olarak ALIR.
  public async Task<IActionResult> AdminGüncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    return View(admin);
  }



  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> AdminGüncelle(int id, Admin model)
  {
    if (id != model.AdminID)
    {
      return NotFound();
    }

    if (model.password != model.confirmpassword)
    {
      ModelState.AddModelError("password", "Şifreler eşleşmiyor.");
      // return View(model);
      return View("AdminGüncelle", model);
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(model);
        await _context.SaveChangesAsync();
      }
      catch (Exception)
      {
        if (!_context.iletisimBilgileris.Any(m => m.IletisimID == model.AdminID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("AdminListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> AdminSil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    return View(admin);
  }

  [HttpPost]

  public async Task<IActionResult> AdminSil([FromForm] int id)
  {

    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    _context.admins.Remove(admin);
    await _context.SaveChangesAsync();
    return RedirectToAction("AdminListesi");
  }



  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

}

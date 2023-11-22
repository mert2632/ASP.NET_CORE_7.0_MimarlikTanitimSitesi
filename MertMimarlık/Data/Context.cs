using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using MertMimarlık.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertMimarlık.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<İletisimBilgileri> iletisimBilgileris => Set<İletisimBilgileri>();
    public DbSet<Admin> admins => Set<Admin>();

}
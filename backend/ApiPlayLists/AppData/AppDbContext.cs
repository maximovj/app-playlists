using System;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.AppData;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

}

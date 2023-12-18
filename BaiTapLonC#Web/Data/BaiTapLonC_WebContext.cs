using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiTapLonC_Web.Models;

namespace BaiTapLonC_Web.Data
{
    public class BaiTapLonC_WebContext : DbContext
    {
        public BaiTapLonC_WebContext (DbContextOptions<BaiTapLonC_WebContext> options)
            : base(options)
        {
        }

        public DbSet<BaiTapLonC_Web.Models.ProductMen> ProductMen { get; set; } = default!;

        public DbSet<BaiTapLonC_Web.Models.ProductWomen>? ProductWomen { get; set; }

        public DbSet<BaiTapLonC_Web.Models.ProductKid>? ProductKid { get; set; }
    }
}

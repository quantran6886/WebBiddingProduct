using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebBiddingProduct.Areas.AreaAdmin.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // tùy chỉnh cách Entity Framework Core tạo và ánh xạ các bảng trong cơ sở dữ liệu
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Tùy chỉnh bảng Identity nếu cần
        }
    }
}

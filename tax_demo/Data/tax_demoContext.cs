using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace tax_demo.Data
{
    public class tax_demoContext(DbContextOptions<tax_demoContext> options) : IdentityDbContext<IdentityUser>(options)
    {
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TaxDemo.Data
{
    public class TaxDemoContext(DbContextOptions<TaxDemoContext> options) : IdentityDbContext<IdentityUser>(options)
    {
    }
}

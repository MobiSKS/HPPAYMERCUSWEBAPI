using HPPay.DataModel;
using Microsoft.EntityFrameworkCore;

namespace HPPay.DataRepository.DataContext
{
    public class HPPayAppContext : DbContext
    {
        public HPPayAppContext() { }
        public HPPayAppContext(DbContextOptions<HPPayAppContext> options) : base(options) { }


        public DbSet<BaseClass> TodoItems { get; set; } = null!;


    }
}

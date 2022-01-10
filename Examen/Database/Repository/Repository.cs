using Database.Models;

namespace Database.Repository
{
    public class Repository<TRepository>
    {
        protected readonly ApplicationContext DbContext;
        public Repository(ApplicationContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
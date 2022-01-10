using System;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository.MonsterRepository
{
    public class MonsterRepository : Repository<Monster>
    {
        public MonsterRepository(ApplicationContext dbContext) : base(dbContext)
        { }
        public async Task<Monster> GetRandomMonsterAsync()
        {
            var count = await DbContext.Monsters.CountAsync();
            if (count == 0)
                throw new ArgumentOutOfRangeException();
            var skipCount = new Random().Next(0, count);
            return await DbContext.Monsters.Skip(skipCount).FirstAsync();
        }
    }
}
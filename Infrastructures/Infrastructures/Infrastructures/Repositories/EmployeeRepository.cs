using Domains.EM.Entites;
using Domains.EM.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;
using UnitOfWork.EntityFramework;

namespace Infrastructures.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAll(int take, int skip)
        {
            var rs = await this.dbSet
                    .Select(p => new Employee()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        HiringDate = p.HiringDate,
                        Position = p.Position,
                        Salary = p.Salary
                    })
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
            return rs;
        }

        public async Task<int> GetTotalCounter()
        {
            return await this.dbSet.CountAsync();
        }
    }
}

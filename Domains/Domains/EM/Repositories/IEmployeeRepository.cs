using Domains.EM.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domains.EM.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee, int>
    {
        Task<IEnumerable<Employee>> GetAll(int take, int skip);
        Task<int> GetTotalCounter();
    }
}

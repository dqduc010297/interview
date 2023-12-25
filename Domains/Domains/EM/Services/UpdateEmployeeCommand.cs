using Domains.EM.Entites;
using Domains.EM.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace Domains.EM.Services
{
    public class UpdateEmployeeCommand
    {
        public class Request : Employee, IRequest<bool>
        {

        }

        public class Handler : IRequestHandler<Request, bool>
        {
            private readonly IEmployeeRepository repository;
            private readonly IUnitOfWork uow;

            public Handler(IEmployeeRepository repository, IUnitOfWork uow)
            {
                this.repository = repository;
                this.uow = uow;
            }

            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var entity = await this.repository.GetEntityByIdAsync(request.Id);
                if (entity == null)
                {
                    throw new Exception();
                }

                entity.Name = request.Name;
                entity.HiringDate = request.HiringDate;
                entity.Salary = request.Salary;

                this.repository.Update(entity);
                int updatedRow = await uow.SaveChangesAsync();
                return updatedRow == 1;
            }
        }
    }
}

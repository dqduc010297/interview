using Domains.EM.Entites;
using Domains.EM.Repositories;
using Domains.EM.Services.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.EM.Services
{
    public class GetEmployeeByIdQuery
    {
        public class Request : IRequest<Employee>
        {
            public int Id { set; get; }
        } 

        public class Handler : IRequestHandler<Request, Employee>
        {
            private readonly IEmployeeRepository repository;

            public Handler(IEmployeeRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Employee> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await this.repository.GetEntityByIdAsync(request.Id);
                return result;
            }
        }
    }
}

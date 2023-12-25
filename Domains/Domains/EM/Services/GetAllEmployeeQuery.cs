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
    public class GetAllEmployeeQuery
    {
        public class Request : PaginationRequest, IRequest<IEnumerable<Employee>>
        {
        } 

        public class Handler : IRequestHandler<Request, IEnumerable<Employee>>
        {
            private readonly IEmployeeRepository repository;

            public Handler(IEmployeeRepository repository)
            {
                this.repository = repository;
            }

            public async Task<IEnumerable<Employee>> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await this.repository.GetAll(request.TakeCount, request.SkipCount);

                return result;
            }
        }
    }
}

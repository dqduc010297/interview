using Domains.EM.Entites;
using Domains.EM.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.EM.Services
{
    public class GetTotalEmployeeCounterQuery
    {
        public class Request : IRequest<int>
        {
        }

        public class Handler : IRequestHandler<Request, int>
        {
            private readonly IEmployeeRepository repository;

            public Handler(IEmployeeRepository repository)
            {
                this.repository = repository;
            }

            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                return await this.repository.GetTotalCounter();
            }
        }
    }
}

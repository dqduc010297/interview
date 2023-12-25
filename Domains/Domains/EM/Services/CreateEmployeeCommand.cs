using Domains.EM.Entites;
using Domains.EM.Repositories;
using MediatR;
using UnitOfWork;

namespace Domains.EM.Services
{
    public class CreateEmployeeCommand
    {
        public class Request : Employee, IRequest<int>
        {

        }

        public class Handler : IRequestHandler<Request, int>
        {
            private readonly IEmployeeRepository repository;
            private readonly IUnitOfWork uow;

            public Handler(IEmployeeRepository repository, IUnitOfWork uow)
            {
                this.repository = repository;
                this.uow = uow;
            }

            public async Task<int> Handle(Request request, CancellationToken cancellationToken)
            {
                this.repository.Create(request);
                int createdId = await uow.SaveChangesAsync();
                return request.Id;
            }
        }
    }
}

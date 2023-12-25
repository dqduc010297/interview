
using Domains.EM.Entites;
using Domains.EM.Repositories;
using MediatR;
using UnitOfWork;

namespace Domains.EM.Services
{
    public class DeleteEmployeeCommand
    {
        public class Request : IRequest<bool>
        {
            public int Id { set; get; }
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
                if (entity == null) { throw new Exception(); }
                this.repository.Delete(entity);
                int deletedRow = await uow.SaveChangesAsync();
                return deletedRow == 1;
            }
        }
    }
}

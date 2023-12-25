namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>() where TRepository : class, IRepository;
        int SaveChanges();

        Task<int> SaveChangesAsync();
        IUnitOfWorkTransactionScope BeginTransaction();
        void Configure(UnitOfWorkOptions unitOfWorkOptions);
    }

    public interface IUnitOfWork<TContext>
    {
        TContext Context { get; set; }
    }
}

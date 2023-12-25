// See https://aka.ms/new-console-template for more information

using Domains.EM.Entites;
using Domains.Identity.Entities;
using Infrastructures;
using Infrastructures.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


IServiceProvider _serviceProvider;
Console.WriteLine("Starting to seed data");
_serviceProvider = ConfigureService(new ServiceCollection(), args);
using (var dbContext = _serviceProvider.GetService<ApplicationDbContext>())
{
    using (var transaction = dbContext.Database.BeginTransaction())
    {
        List<string> firstName = new List<string>() { "Nguyễn", "Trần", "Lý", "Trần", "Lê" };
        List<string> middleName = new List<string>() { "Ngân", "Ái", "Ngọc", "Uyên", "Phương" };
        List<string> lastName = new List<string>() { "Thương", "Mai", "Trúc", "Thảo", "Trang" };
        List<string> position = new List<string>() { "Project Manager", "Developer", "Quality Control", "Solution Architecture", "Business Analyst" };

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100; i++)
        {
            int j = new Random().Next(0, 4);
            Employee employee = new Employee()
            {
                Name = $"{firstName[j]} {middleName[j]} {lastName[j]}",
                Position = position[j],
                HiringDate = DateTime.Now.AddYears(j * -1).AddDays(j),
                Salary = 1000 * (j + 1)
            };
            employees.Add(employee);
        }
        dbContext.AddRange(employees);
        await dbContext.SaveChangesAsync();
        transaction.Commit();
        Console.WriteLine("Commit all seed");
    }
}
Console.WriteLine("Seed data successfull");
IServiceProvider ConfigureService(IServiceCollection services, string[] args)
{
    var dbContextFactory = new DesignTimeDbContextFactory();

    services.AddLogging();
    services.AddScoped<ApplicationDbContext>(p => dbContextFactory.CreateDbContext(args));
    return services.BuildServiceProvider();
}
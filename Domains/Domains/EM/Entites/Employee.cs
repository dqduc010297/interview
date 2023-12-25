using Domain.Entities;

namespace Domains.EM.Entites
{
    public class Employee : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { set; get; }
        public DateTime? HiringDate { set; get; }
        public int Salary { set; get; }
    }
}

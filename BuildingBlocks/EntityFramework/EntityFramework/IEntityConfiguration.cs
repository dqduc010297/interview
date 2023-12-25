using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EntityFramework
{
    public interface IEntityConfiguration
    {
        void Configure(ModelBuilder builder);
    }
}

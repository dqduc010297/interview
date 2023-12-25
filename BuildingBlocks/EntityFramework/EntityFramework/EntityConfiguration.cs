using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public abstract class EntityConfiguration<TEntity> : IEntityConfiguration where TEntity : class
    {
        public void Configure(ModelBuilder builder)
        {
            var typeBuilder = builder.Entity<TEntity>();

            OnConfigure(typeBuilder);
        }

        public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);

    }
}

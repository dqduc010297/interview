
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IVersionedEntity : IEntity
    {
        byte[] RowVersion { get; set; }
    }


    public interface IVersionedEntity<TKeyType> : IVersionedEntity, IEntity<TKeyType>
    {
    }
}

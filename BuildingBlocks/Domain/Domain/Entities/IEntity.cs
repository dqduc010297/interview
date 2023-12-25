using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IEntity
    {
    }
    public interface IEntity<TType> : IEntity
    {
        /// <summary>
        /// Identity key for the entities
        /// </summary>
        TType Id { get; set; }
    }
}

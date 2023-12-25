using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Identity
{
    public class UserIdentity<TType>
    {
        public TType Id { get; set; }
        public string UserName { get; set; }

    }
}

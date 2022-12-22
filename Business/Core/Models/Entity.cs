using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }
    }
}

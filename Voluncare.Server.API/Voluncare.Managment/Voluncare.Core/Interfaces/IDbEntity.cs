using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voluncare.Core.Interfaces
{
    public interface IDbEntity
    {
        public Guid ID { get; set; }
    }
}

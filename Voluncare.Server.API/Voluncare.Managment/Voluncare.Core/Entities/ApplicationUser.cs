using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IDbEntity
    {
        public Guid ID { get; set; }
    }
}

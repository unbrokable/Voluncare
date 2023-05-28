using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Enums;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IDbEntity
    {
        public ApllicationUserType ApllicationUserType { get; set; }
    }
}

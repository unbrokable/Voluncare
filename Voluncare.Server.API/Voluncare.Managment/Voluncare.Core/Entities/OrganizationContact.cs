using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class OrganizationContact : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public VolunteerOrganization Organization { get; set; }
    }
}

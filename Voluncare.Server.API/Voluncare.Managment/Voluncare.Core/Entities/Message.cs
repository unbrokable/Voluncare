using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class Message : IDbEntity
    {
        public Guid Id { get; set; }

        public Guid ChatId { get; set; }

        public Guid SenderId { get; set; }

        public string Value { get; set; }

        public DateTime Date { get; set; }

        public Chat Chat { get; set; }
    }
}

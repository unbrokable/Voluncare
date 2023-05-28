using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Models
{
    public class ItemPage<TEntity>
    where TEntity : IDbEntity
    {
        public int PageCount { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public long TotalItemCount { get; }

        public IEnumerable<TEntity> Items { get; }

        public ItemPage(int pageNumber, int pageSize, long totalItemCount, IEnumerable<TEntity> items)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
            this.TotalItemCount = totalItemCount;
            this.Items = items;
        }
    }
}

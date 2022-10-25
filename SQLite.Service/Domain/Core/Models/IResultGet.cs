using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLite.Service.Domain.Core.Models
{
    public interface IResultGet<TEntity>
    {
        string Context { get; set; }
        int TotalCount { get; set; }
        IEnumerable<TEntity> Data { get; set; }
    }
}

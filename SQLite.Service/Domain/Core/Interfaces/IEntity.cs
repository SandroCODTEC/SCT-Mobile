using System;
using System.Collections.Generic;
using System.Text;

namespace SQLite.Service.Domain.Core.Interfaces
{
   public interface IEntity
    {
        object Oid { get; set; }
    }
    public interface IEntity<T> : IEntity
    {
        new T Oid { get; set; }
        bool Validate();
    }
}

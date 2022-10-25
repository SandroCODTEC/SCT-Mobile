using SQLite.Service.Domain.Core.Interfaces;
using System;
using System.Linq;
using System.Net;

namespace SQLite.Service.Domain.Core.Services.Helpers
{
    public interface IResult<T>
    {
        bool IsSuccess { get; }
    }
}

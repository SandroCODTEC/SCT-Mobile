using System;
using System.Linq;

namespace SQLite.Service.Domain.Core.Services.Helpers
{
    public record Success<T>(T Value) : IResult<T>
    {
        public bool IsSuccess => true;
    }
}

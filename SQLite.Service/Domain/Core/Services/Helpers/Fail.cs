using System;
using System.Linq;

namespace SQLite.Service.Domain.Core.Services.Helpers
{
    public record Fail<T>(Error Error) : IResult<T>
    {
        public bool IsSuccess => false;
    }
}

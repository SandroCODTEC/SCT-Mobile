using System;
using System.Linq;

namespace SQLite.Service.Domain.Core.Services.Helpers
{
    public record Error(int? Status, string Message);
}

using SQLite.Service.Domain.Core.Interfaces;
using System;
using System.Linq;

namespace SQLite.Service.Domain.Core.Services.Helpers
{
    public static class OptionsClientExtensions
    {
        public static IResult<T> ThenIfOk<T>(this IResult<T> previous, Func<T, IResult<T>> func) where T : class
        {
            return previous switch
            {
                Fail<T> error => error,
                Success<T> ok => func(ok.Value),
                _ => throw new NotImplementedException()
            };
        }
        public static T Then<T>(this IResult<T> previous) where T : class
        {
            return previous switch
            {
                Success<T> ok => ok.Value,
                _ => throw new Exception("Resultado esperado falhou!")
            };
        }
        public static Error Catch<T>(this IResult<T> previous) where T : class
        {
            return previous switch
            {
                Fail<T> fail => fail.Error,
                _ => throw new Exception("Resultado esperado falhou!")
            };
        }
        public static T ThenEntity<T>(this IResult<T> previous) where T : IEntity
        {
            return previous switch
            {
                Success<T> ok => ok.Value,
                _ => throw new Exception("Resultado esperado falhou!")
            };
        }
        public static Error CatchFail<T>(this IResult<T> previous) where T : IEntity
        {
            return previous switch
            {
                Fail<T> fail => fail.Error,
                _ => throw new Exception("Resultado esperado falhou!")
            };
        }
    }
}

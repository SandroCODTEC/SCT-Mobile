using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SQLite.Service.Domain.Core.Models
{
    public class ResultGet<TEntity> : IResultGet<TEntity>
    {
        [JsonPropertyName("@odata.context")]
        public string Context { get; set; }
        [JsonPropertyName("@odata.count")] 
        public int TotalCount { get; set; }
        [JsonPropertyName("value")]
        public IEnumerable<TEntity> Data { get; set; }
    }
}

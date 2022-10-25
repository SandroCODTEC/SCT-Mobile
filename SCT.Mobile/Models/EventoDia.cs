using SQLite;
using SQLite.Service.Domain.Core.Entities;
using SQLiteNetExtensions.Attributes;

namespace SCT.Mobile.Models
{
    [Table("EventoDias")]
    public class EventoDia : Entity<Guid>
    {

        DateTime data;
        [ForeignKey(typeof(Evento))]
        public Guid EventoId { get; set; }

        public DateTime Data
        {
            get => data;
            set => SetPropertyValue(ref data, value);
        }
    }
}

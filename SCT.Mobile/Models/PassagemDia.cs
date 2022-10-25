using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SCT.Mobile.Models
{
    [Table("PassagemDias")]
    public class PassagemDia
    {
        [ForeignKey(typeof(Passagem))]
        public int PassagemId { get; set; }

        [ForeignKey(typeof(EventoDia))]
        public int EventoDiaId { get; set; }
    }
}

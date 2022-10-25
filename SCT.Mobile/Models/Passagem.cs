using DevExpress.Maui.DataForm;
using DevExpress.Xpo;
using Javax.Security.Auth;
using SCT.Mobile.Helpers;
using SQLite;
using SQLite.Service.Domain.Core.Entities;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SCT.Mobile.Models
{
    [Table("Passagens")]
    public class Passagem : Entity<Guid>
    {

        decimal valorPago;
        Guid saida;
        Guid passageiro;
        Guid evento;
        int grupo;


        [DataFormComboBoxEditor(ValueMember = "Oid", DisplayMember = "Nome")]
        [ForeignKey(typeof(Passageiro))]
        public Guid PassageiroId
        {
            get => passageiro;
            set => SetPropertyValue(ref passageiro, value);
        }
        [OneToOne]
        public Passageiro Passageiro { get; set; }
        public Guid Evento
        {
            get => evento;
            set => SetPropertyValue(ref evento, value);
        }

        [DataFormComboBoxEditor(ValueMember = "Id", DisplayMember = "Nome")]
        public int Grupo
        {
            get => grupo;
            set => SetPropertyValue(ref grupo, value);
        }
        [ForeignKey(typeof(Saida))]
        public Guid SaidaId
        {
            get => saida;
            set => SetPropertyValue(ref saida, value);
        }
        [OneToOne]
        public Saida Saida { get; set; }

        public decimal ValorPago
        {
            get => valorPago;
            set => SetPropertyValue(ref valorPago, value);
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Dependente> Dependentes { get; set; }

        [ManyToMany(typeof(PassagemDia))]
        public List<EventoDia> Dias { get; set; }
    }
}

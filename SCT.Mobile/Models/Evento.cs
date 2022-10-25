using DevExpress.Maui.DataForm;
using DevExpress.Xpo;
using SQLite;
using SQLite.Service.Domain.Core.Entities;
using SQLiteNetExtensions.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SCT.Mobile.Models
{
    [Table("Eventos")]
    public class Evento : Entity<Guid>
    {
        const string eventoGroup = "Dados do Evento";
        bool concluido;
        decimal valorPassagem;
        DateTime dataInicial;
        DateTime dataFinal;
        string tema;
        string descricao;

        //[DataFormTextEditor(Placeholder = "Nº de Celular")]
        //[StringLength(15, ErrorMessage = "O campo não pode ter mais de 15 caracteres!")]
        //[DataFormDisplayOptions(LabelIcon = "editor_phone", LabelText = "Nº de Celular", GroupName = ajudanteGroup)]
        //[SQLite.MaxLength(15)]
        //[DataFormMaskedEditor(Mask = "(00) 00000-0000", Keyboard = "Telephone")]



        
        [DataFormDisplayOptions(LabelIcon = "editor_text", LabelText = "Descrição", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Descrição")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória!"), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Descricao
        {
            get => descricao;
            set => SetPropertyValue(ref descricao, value);
        }

        [DataFormDisplayOptions(LabelIcon = "editor_text", LabelText = "Descrição", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Tema")]
        [Required(ErrorMessage = "O tema do evento é obrigatório!"), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Tema
        {
            get => tema;
            set => SetPropertyValue(ref tema, value);
        }

        [DataFormDisplayOptions(LabelIcon = "editor_date", LabelText = "Data Inicial", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Data Inicial")]
        [Required(ErrorMessage = "A data inicial do evento é obrigatória!")]
        public DateTime DataInicial
        {
            get => dataInicial;
            set => SetPropertyValue(ref dataInicial, value);
        }
        [DataFormDisplayOptions(LabelIcon = "editor_date", LabelText = "Data Final", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Data Final")]
        [Required(ErrorMessage = "A data final do é obrigatória!")]
        public DateTime DataFinal
        {
            get => dataFinal;
            set => SetPropertyValue(ref dataFinal, value);
        }
        [DataFormDisplayOptions(LabelIcon = "editor_currency", LabelText = "Valor da passagem", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Valor da passagem")]
        public decimal ValorPassagem
        {
            get => valorPassagem;
            set => SetPropertyValue(ref valorPassagem, value);
        }
        
        [DataFormDisplayOptions(LabelIcon = "editor_check", LabelText = "Concluído", GroupName = eventoGroup), DataFormTextEditor(Placeholder = "Concluído")]
        public bool Concluido
        {
            get => concluido;
            set => SetPropertyValue(ref concluido, value);
        }
        
        
        [DataFormDisplayOptions(LabelIcon = "editor_check", LabelText = "Concluído", GroupName = "Saídas")]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<EventoDia> Dias { get; set; }
    }
}

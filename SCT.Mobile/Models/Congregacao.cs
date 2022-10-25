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
    [Table("Congregacao")]
    public class Congregacao : Entity<Guid>
    {
        public Congregacao()
        {
            Nome = string.Empty;
            Responsavel = string.Empty;
            EmailResponsavel = string.Empty;
            CelularResponsavel = string.Empty;
            Ajudante = string.Empty;
            EmailAjudante = string.Empty;
            CelularAjudante = string.Empty;
            Saidas = new List<Saida>();
        }
        string nome;
        List<Saida> saidas;
        string celularAjudante;
        string emailAjudante;
        string ajudante;
        int previsaoPassageiros;
        string responsavel;
        string celularResponsavel;
        string emailResponsavel;

        const string dadosDaCongregacao = "Dados da Congregação";
        const string responsavelGroup = "Responsável pelo Arranjo na Congregação";
        const string ajudanteGroup = "Ajudante do Arranjo";

        [DataFormItemPosition(RowOrder = 1)]
        [Required(ErrorMessage = "O nome da congregação é obrigatório!"),
         StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [DataFormTextEditor(Placeholder = "Nome da congregação")]
        [DataFormDisplayOptions(LabelIcon = "bo_congregacao", LabelText = "Nome", GroupName = dadosDaCongregacao)]
        [SQLite.MaxLength(100)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(ref nome, value);
        }
        public override string ToString() => Nome;


        [DataFormItemPosition(RowOrder = 2)]
        [Required(ErrorMessage = "A previsão de passageiros é obrigatória!")]
        [DataFormTextEditor(Placeholder = "Previsão de passageiros")]
        [DataFormDisplayOptions(LabelIcon = "bo_passageiro", LabelText = "Previsão de passageiros", GroupName = dadosDaCongregacao)]
        public int PrevisaoPassageiros
        {
            get => previsaoPassageiros;
            set => SetPropertyValue(ref previsaoPassageiros, value);
        }


        [DataFormItemPosition(RowOrder = 3)]
        [DataFormTextEditor(Placeholder = "Nome")]
        [DataFormDisplayOptions(LabelIcon = "editor_lead", LabelText = "Responsável", GroupName = responsavelGroup)]
        [Required(ErrorMessage = "O nome é obrigatório!"),
            StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Responsavel
        {
            get => responsavel;
            set => SetPropertyValue(ref responsavel, value);
        }

        [DataFormItemPosition(RowOrder = 4)]
        [DataFormTextEditor(Placeholder = "Email")]
        [DataFormDisplayOptions(LabelIcon = "editor_email", LabelText = "Email", GroupName = responsavelGroup)]
        [SQLite.MaxLength(100)]
        public string EmailResponsavel
        {
            get => emailResponsavel;
            set => SetPropertyValue(ref emailResponsavel, value);
        }

        [DataFormItemPosition(RowOrder = 5)]
        [DataFormTextEditor(Placeholder = "Nº de Celular")]
        [Required(ErrorMessage = "Campo obrigatório!"),
            StringLength(15, ErrorMessage = "O campo não pode ter mais de 15 caracteres!")]
        [DataFormDisplayOptions(LabelIcon = "editor_phone", LabelText = "Nº de Celular", GroupName = responsavelGroup)]
        [SQLite.MaxLength(15)]
        [DataFormMaskedEditor(Mask = "(00) 00000-0000", Keyboard = "Telephone")]
        public string CelularResponsavel
        {
            get => celularResponsavel;
            set => SetPropertyValue(ref celularResponsavel, value);
        }

        [DataFormItemPosition(RowOrder = 6)]
        [DataFormTextEditor(Placeholder = "Nome")]
        [DataFormDisplayOptions(LabelIcon = "editor_lead", LabelText = "Ajudante", GroupName = ajudanteGroup)]
        [StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Ajudante
        {
            get => ajudante;
            set => SetPropertyValue(ref ajudante, value);
        }

        [DataFormItemPosition(RowOrder = 7)]
        [DataFormTextEditor(Placeholder = "Email")]
        [DataFormDisplayOptions(LabelIcon = "editor_email", LabelText = "Email", GroupName = ajudanteGroup)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string EmailAjudante
        {
            get => emailAjudante;
            set => SetPropertyValue(ref emailAjudante, value);
        }

        [DataFormItemPosition(RowOrder = 8)]
        [DataFormTextEditor(Placeholder = "Nº de Celular")]
        [StringLength(15, ErrorMessage = "O campo não pode ter mais de 15 caracteres!")]
        [DataFormDisplayOptions(LabelIcon = "editor_phone", LabelText = "Nº de Celular", GroupName = ajudanteGroup)]
        [SQLite.MaxLength(15)]
        [DataFormMaskedEditor(Mask = "(00) 00000-0000", Keyboard = "Telephone")]
        public string CelularAjudante
        {
            get => celularAjudante;
            set => SetPropertyValue(ref celularAjudante, value);
        }

        [DataFormDisplayOptions(IsVisible = false)]
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Saida> Saidas
        {
            get => saidas;
            set => SetPropertyValue(ref saidas, value);
        }

    }
}

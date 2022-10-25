using DevExpress.Maui.DataForm;
using SCT.Mobile.Helpers;
using SQLite;
using SQLite.Service.Domain.Core.Entities;
using SQLiteNetExtensions.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SCT.Mobile.Models
{
    [Table("Dependentes")]
    public class Dependente : Entity<Guid>
    {
        public Dependente()
        {
            Nome = "";
            TipoDocumento = TipoDocumento.CPF;
            Documento = "";
        }
        string nome;
        TipoDocumento tipoDocumento;
        string documento;

        [ForeignKey(typeof(Passagem))]
        public Guid Passagem { get; set; }

        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 1)]
        [DataFormDisplayOptions(LabelIcon = "editor_text", LabelText = "Nome", GroupName = "Dados do Dependente")]
        [Required(ErrorMessage = "O nome do dependente é obrigatório!"), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(ref nome, value);
        }

        [DataFormItemPosition(RowOrder = 2, ItemOrderInRow = 1)]
        [DataFormDisplayOptions(LabelIcon = "editor_doc", GroupName = "Dados do Passageiro")]
        [Required(ErrorMessage = "O tipo de documento é obrigatório!")]
        public TipoDocumento TipoDocumento
        {
            get => tipoDocumento;
            set => SetPropertyValue(ref tipoDocumento, value, nameof(TipoDocumento));
        }
        [DataFormItemPosition(RowOrder = 2, ItemOrderInRow = 2)]
        [DataFormDisplayOptions(IsLabelVisible = false, GroupName = "Passageiro")]
        [Required(ErrorMessage = "O documento é obrigatório!"), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Documento
        {
            get => documento;
            set => SetPropertyValue(ref documento, value);
        }

        [DataFormDisplayOptions(IsVisible = false)]
        public string Documentacao => $"{TipoDocumento} {Documento}";
        [DataFormDisplayOptions(IsVisible = false)]
        public string Avatar => Nome.GetFirstsLetter();

        public override string ToString()
        {
            return Nome;
        }
    }
}

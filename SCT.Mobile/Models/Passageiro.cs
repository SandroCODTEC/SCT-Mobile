using DevExpress.Maui.DataForm;
using SCT.Mobile.Helpers;
using SQLite;
using SQLite.Service.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SCT.Mobile.Models
{
    [Table("Passageiros")]
    public class Passageiro : Entity<Guid>
    {
        public Passageiro()
        {
            Nome = "";
            TipoDocumento = TipoDocumento.CPF;
            Documento = "";
            Celular = "";
        }
        bool ativo;
        string nome;
        string celular;
        TipoDocumento tipoDocumento;
        string documento;

        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 1)]
        [DataFormDisplayOptions(LabelIcon = "editor_text", LabelText = "Nome", GroupName = "Passageiro")]
        [Required(ErrorMessage = "O nome do passageiro é obrigatório!"), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        [SQLite.MaxLength(100)]
        public string Nome
        {
            get => nome;
            set => SetPropertyValue(ref nome, value);
        }

        [DataFormItemPosition(RowOrder = 2, ItemOrderInRow = 1)]
        [DataFormDisplayOptions(LabelIcon = "editor_doc", GroupName = "Passageiro")]

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

        [DataFormMaskedEditor(Mask = "(00) 00000-0000", Keyboard = "Telephone")]
        [DataFormDisplayOptions(LabelIcon = "editor_phone", GroupName = "Passageiro")]

        [SQLite.MaxLength(15), StringLength(15, ErrorMessage = "O campo não pode ter mais de 15 caracteres!")]
        public string Celular
        {
            get => celular;
            set => SetPropertyValue(ref celular, value);
        }
        
        [DataFormDisplayOptions(LabelIcon = "editor_date", GroupName = "Passageiro")]
        public bool Ativo
        {
            get => ativo;
            set => SetPropertyValue(ref ativo, value);
        }

        [DataFormDisplayOptions(IsVisible =false)]
        public string Documentacao => $"{this.TipoDocumento} {Documento}";
        [DataFormDisplayOptions(IsVisible =false)]
        public string Avatar => Nome.GetFirstsLetter();

        public override string ToString()
        {
            return Nome;
        }
    }
}

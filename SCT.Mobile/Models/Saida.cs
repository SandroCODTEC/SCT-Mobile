using DevExpress.Maui.DataForm;
using DevExpress.Xpo;
using SCT.Mobile.Helpers;
using SQLite;
using SQLite.Service.Domain.Core.Entities;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SCT.Mobile.Models
{
    [Table("Saidas")]
    public class Saida : Entity<Guid>
    {
        const string endereco = "Endereço";
        const string localizacao = "Localização";
        Guid congregacao;
        long latitude;
        long longitude;
        string uF;
        string cidade;
        string bairro;
        string complemento;
        string numero;
        string logradouro;
        TimeSpan horario;
        int parada;

        [ForeignKey(typeof(Congregacao))]
        [DataFormDisplayOptions(IsVisible = false)]
        public Guid Congregacao
        {
            get => congregacao;
            set => SetPropertyValue(ref congregacao, value);
        }
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_time", LabelText = "Horário de Saída", GroupName = "Horário de Saída")]
        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 1)]
        [Required(ErrorMessage = "Informe o horário desta saída!")]
        public TimeSpan Horario
        {
            get => horario;
            set => SetPropertyValue(ref horario, value);
        }
        [DataFormDisplayOptions(IsLabelVisible = false, LabelIcon = "editor_empty", LabelText = "Parada", GroupName = "Horário de Saída")]
        [DataFormItemPosition(RowOrder = 1, ItemOrderInRow = 1)]
        [Required(ErrorMessage = "Informe a ordem de parada!")]
        public int Parada
        {
            get => parada;
            set => SetPropertyValue(ref parada, value);
        }

        [DataFormTextEditor(Placeholder = "Logradouro")]
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_location", LabelText = "Logradouro", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 2, ItemOrderInRow = 1)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string Logradouro
        {
            get => logradouro;
            set => SetPropertyValue(ref logradouro, value);
        }

        [DataFormTextEditor(Placeholder = "Número")]
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_empty", LabelText = "Número", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 3, ItemOrderInRow = 1)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string Numero
        {
            get => numero;
            set => SetPropertyValue(ref numero, value);
        }

        [DataFormTextEditor(Placeholder = "Complemento")]
        [DataFormDisplayOptions(IsLabelVisible = false , LabelText = "Complemento", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 3, ItemOrderInRow = 2)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string Complemento
        {
            get => complemento;
            set => SetPropertyValue(ref complemento, value);
        }

        [DataFormTextEditor(Placeholder = "Bairro")]
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_empty", LabelText = "", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 4)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string Bairro
        {
            get => bairro;
            set => SetPropertyValue(ref bairro, value);
        }

        [DataFormTextEditor(Placeholder = "Cidade")]
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_empty", LabelText = "Cidade", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 5, ItemOrderInRow = 1)]
        [SQLite.MaxLength(100), StringLength(100, ErrorMessage = "O campo não pode ter mais de 100 caracteres!")]
        public string Cidade
        {
            get => cidade;
            set => SetPropertyValue(ref cidade, value);
        }

        [DataFormTextEditor(Placeholder = "UF")]
        [DataFormDisplayOptions(IsLabelVisible = false , LabelText = "UF", GroupName = endereco)]
        [DataFormItemPosition(RowOrder = 5, ItemOrderInRow = 2)]
        [SQLite.MaxLength(2)]
        public string UF
        {
            get => uF;
            set => SetPropertyValue(ref uF, value);
        }
        [DataFormTextEditor(Placeholder = "Longitude")]
        [DataFormDisplayOptions(IsLabelVisible = true , LabelIcon = "editor_location", LabelText = "Longitude", GroupName = localizacao)]
        [DataFormItemPosition(RowOrder = 6, ItemOrderInRow = 1)]
        public long Longitude
        {
            get => longitude;
            set => SetPropertyValue(ref longitude, value);
        }
        [DataFormTextEditor(Placeholder = "Latitude")]
        [DataFormDisplayOptions(IsLabelVisible = false , LabelIcon = "editor_empty", LabelText = "Latitude", GroupName = localizacao)]
        [DataFormItemPosition(RowOrder = 6, ItemOrderInRow = 2)]
        public long Latitude
        {
            get => latitude;
            set => SetPropertyValue(ref latitude, value);
        }


        public override string ToString()
        {
            return $"{Logradouro}, {Numero} {Complemento}, {Bairro} - {Cidade} - {UF}";
        }
    }
}

namespace DataForm_ComboBoxEditor
{
    public class GrupoViagem
    {
        public GrupoViagem()
        {

        }
        public GrupoViagem(int id, Color cor)
        {
            Id = id;
            Nome = $"GRUPO {id}";
            Cor = cor;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public Color Cor { get; set; }

    }
}
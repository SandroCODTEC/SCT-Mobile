using System.Collections;
using System.Collections.Generic;
using DevExpress.Maui.DataForm;
using SCT.Mobile.Services;

namespace DataForm_ComboBoxEditor
{
    public static class ValuesDataProvider
    {
        private static IEnumerable<GrupoViagem> grupos = new List<GrupoViagem>() {
            new GrupoViagem() { Id = 0, Nome  = "NENHUM", Cor = Colors.Black },
            new GrupoViagem(1, Colors.IndianRed) ,
            new GrupoViagem(2, Colors.Red) ,
            new GrupoViagem(3, Colors.Maroon),
            new GrupoViagem(4, Colors.Tomato),
            new GrupoViagem(5, Colors.Chocolate),
            new GrupoViagem(6, Colors.Peru),
            new GrupoViagem(7, Colors.SaddleBrown),
            new GrupoViagem(8, Colors.OrangeRed),
            new GrupoViagem(9, Colors.DarkOrange),
            new GrupoViagem(10, Colors.Tan),
            new GrupoViagem(11, Colors.Orange),
            new GrupoViagem(12, Colors.Goldenrod),
            new GrupoViagem(13, Colors.DarkKhaki),
            new GrupoViagem(14, Colors.Olive),
            new GrupoViagem(15, Colors.OliveDrab),
            new GrupoViagem(16, Colors.DarkOliveGreen),
            new GrupoViagem(17, Colors.DarkSeaGreen),
            new GrupoViagem(18, Colors.Green),
            new GrupoViagem(19, Colors.Teal),
            new GrupoViagem(20, Colors.CadetBlue),
            new GrupoViagem(21, Colors.SteelBlue),
            new GrupoViagem(22, Colors.RoyalBlue),
            new GrupoViagem(23, Colors.Blue),
            new GrupoViagem(24, Colors.DarkBlue),
            new GrupoViagem(25, Colors.BlueViolet),
            new GrupoViagem(26, Colors.MediumOrchid),
            new GrupoViagem(27, Colors.Purple),
            new GrupoViagem(28, Colors.DarkViolet),
            new GrupoViagem(29, Colors.DeepPink),
            new GrupoViagem(30, Colors.PaleVioletRed),
        };
        public static IEnumerable<GrupoViagem> Grupos => grupos;
    }
}
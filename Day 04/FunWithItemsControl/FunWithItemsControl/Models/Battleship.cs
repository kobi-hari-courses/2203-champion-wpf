using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FunWithItemsControl
{
    public class Battleship: BindableBase
    {
        private string _DisplayName = "";
        public string DisplayName
        {
            get => _DisplayName;
            set => SetProperty(ref _DisplayName, value);
        }

        private Color _Color = Colors.Black;
        public Color Color
        {
            get => _Color;
            set => SetProperty(ref _Color, value);
        }

        private double _X = 0;
        public double X
        {
            get => _X;
            set => SetProperty(ref _X, value);
        }

        private double _Y = 0;
        public double Y
        {
            get => _Y;
            set => SetProperty(ref _Y, value);
        }


    }
}

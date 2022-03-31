using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FunWithBinding
{
    public class Person: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string FullName { get; set; } = "";


        private Color _favoriteColor;
        public Color FavoriteColor
        {
            get { return _favoriteColor; }
            set { 
                _favoriteColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FavoriteColor"));
            }
        }

    }
}

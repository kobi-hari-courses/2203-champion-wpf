using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FunWithItemsControl
{
    public class Fleet: BindableBase
    {
        private ObservableCollection<Battleship> _Ships = new ObservableCollection<Battleship>();
        public ObservableCollection<Battleship> Ships
        {
            get => _Ships;
            set => SetProperty(ref _Ships, value);
        }

        public Fleet()
        {
            _Ships = new ObservableCollection<Battleship>
            {
                new Battleship
                {
                    DisplayName = "First",
                    Color = Colors.Red,
                    X = 0,
                    Y = 0
                },
                new Battleship
                {
                    DisplayName  = "Second",
                    Color = Colors.Yellow,
                    X = 100,
                    Y = 0
                },
                new Battleship
                {
                    DisplayName  = "Third",
                    Color = Colors.Green,
                    X = 0,
                    Y = 100
                },
                new Battleship
                {
                    DisplayName  = "Fourth",
                    Color = Colors.Magenta,
                    X = 100,
                    Y = 100
                },
                new Battleship
                {
                    DisplayName  = "Fifth",
                    Color = Colors.Cyan,
                    X = -100,
                    Y = -100
                }
            };
        }


    }
}

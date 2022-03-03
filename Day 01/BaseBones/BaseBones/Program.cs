using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BaseBones
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var win = new Window();
            win.Title = "Hello World";

            var sp = new StackPanel();

            var ellipse = new Ellipse()
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Red
            };

            sp.Children.Add(ellipse);

            var tb = new TextBlock()
            {
                Text = "Hello",
                Foreground = Brushes.Blue,
                FontSize = 16.0
            };

            sp.Children.Add(tb);

            win.Content = sp;

            var app = new Application();

            app.Run(win);

        }
    }
}

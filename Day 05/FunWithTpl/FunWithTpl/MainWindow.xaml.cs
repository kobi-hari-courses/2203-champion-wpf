using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunWithTpl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void btnStart_Click(object sender, RoutedEventArgs e)
        //{
        //    btnStart.IsEnabled = false;
        //    txt.Text = "Please wait";
        //    progress.IsIndeterminate = true;

        //    var task = PrimesCalculator
        //            .GetAllPrimesAsync(2, 350000);

        //    var task2 = task.ContinueWith(t =>
        //    {
        //        listBox.ItemsSource = t.Result;

        //        progress.IsIndeterminate = false;
        //        txt.Text = "Completed";
        //        btnStart.IsEnabled = true;
        //        return true;

        //    }, TaskScheduler.FromCurrentSynchronizationContext());


        //}


        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            txt.Text = "Please wait";
            progress.IsIndeterminate = true;

            var task = PrimesCalculator
                    .GetAllPrimesAsync(2, 350000);

            listBox.ItemsSource = await task;

            progress.IsIndeterminate = false;
            txt.Text = "Completed";
            btnStart.IsEnabled = true;

        }
    }
}

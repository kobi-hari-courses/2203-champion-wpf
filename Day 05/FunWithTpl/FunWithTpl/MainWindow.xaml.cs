using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        private CancellationTokenSource? _cts = null;
        private TaskCompletionSource<(int from, int to)>? _tcs = null;

        private Task<(int from, int to)> GetRangeFromUser(CancellationToken? ct = null)
        {
            _tcs = new TaskCompletionSource<(int from, int to)>();
            using (ct?.Register(() =>
            {
                _tcs.SetCanceled();
                _tcs = null;
                rangePanel.Visibility = Visibility.Collapsed;
            }))

            rangePanel.Visibility = Visibility.Visible;
            return _tcs.Task;
        }

        private void btnSetRange_Click(object sender, RoutedEventArgs e)
        {
            var from = int.Parse(txtFrom.Text);
            var @to = int.Parse(txtTo.Text);

            _tcs?.SetResult((from, to));
            _tcs = null;
            rangePanel.Visibility = Visibility.Collapsed;
        }

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
            Debug.WriteLine("A");
            await runCalc();
            Debug.WriteLine("B");

        }

        private async Task<int> runCalc()
        {
            var watch = new Stopwatch();

            try
            {
                Debug.WriteLine("1");
                btnStart.IsEnabled = false;
                txt.Text = "Please wait";
                _cts = new CancellationTokenSource();

                var range = await GetRangeFromUser(_cts.Token);

                watch.Start();
                var progressReport = new Progress<double>(val => progress.Value = val);

                //progress.IsIndeterminate = true;

                var task = PrimesCalculator
                        .GetAllPrimesAsync(range.from, range.to, _cts.Token, progressReport);
                var res = await task;

                //var tasks = Enumerable.Range(0, 5)
                //    .Select(i => PrimesCalculator.GetAllPrimesAsync(70000 * i, 70000 * (i + 1) - 1));
                //var task = Task.WhenAll(tasks);

                //var results = await task;

                //var res = results.SelectMany(i => i).ToList();


                Debug.WriteLine("2");
                listBox.ItemsSource = res;
                Debug.WriteLine("3");

                txt.Text = "Completed";
                Debug.WriteLine("4");
                _cts = null;

            } catch (OperationCanceledException)
            {
                txt.Text = "Operation Cancelled";
            }
            finally
            {
                //progress.IsIndeterminate = false;
                btnStart.IsEnabled = true;
                watch.Stop();
                Debug.WriteLine($"Operation took {watch.Elapsed} to complete");

            }
            return 2 + 2;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _cts?.Cancel();
        }

    }
}

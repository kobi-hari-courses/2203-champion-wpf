using FunWithMvvm.Components.Shell;
using FunWithMvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FunWithMvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var provider = serviceCollection.BuildServiceProvider();
            var vm = provider.GetRequiredService<ShellVm>();


            var win = new Window();
            var shellView = new ShellView();
            shellView.DataContext = vm;
            win.Content = shellView;
            win.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<ShellVm>();
            services.AddSingleton<ITitleService, TitleService>();
        }
    }
}

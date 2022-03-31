using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace FunWithDependencyProperties
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var co1 = new CustomObject();

            var source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);

            int a1 = co1.AAA;

            var style = new Style()
            {
                TargetType = typeof(CustomObject)
            };

            style.Setters.Add(new Setter
            {
                Property = CustomObject.AAAProperty, 
                Value = 200
            });

            co1.Style = style;
            int a2 = co1.AAA;
            source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);


            co1.Max = 300;
            int a2_5 = co1.AAA;
            source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);


            co1.AAA = 30;
            int a3 = co1.AAA;
            source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);

            co1.ClearValue(CustomObject.AAAProperty);

            int a4 = co1.AAA;
            source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);

            co1.Style = null;

            int a5 = co1.AAA;
            source = DependencyPropertyHelper.GetValueSource(co1, CustomObject.AAAProperty);


            var el = new Ellipse();
        }
    }
}

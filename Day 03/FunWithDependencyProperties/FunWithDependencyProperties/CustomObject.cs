using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunWithDependencyProperties
{
    public class CustomObject: FrameworkElement
    {


        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(CustomObject), 
                new FrameworkPropertyMetadata(150, OnMaxChanged));

        private static void OnMaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(AAAProperty);
        }



        public static readonly DependencyProperty AAAProperty = DependencyProperty.Register(
            nameof(AAA), typeof(int), typeof(CustomObject), 
            new PropertyMetadata(42, OnAaaChanged, OnAaaCoerced));

        private static object OnAaaCoerced(DependencyObject d, object baseValue)
        {
            var co = d as CustomObject;
            if (co == null) return baseValue;

            int val = (int)baseValue;
            if (val > co.Max) return co.Max;
            if (val < 0) return 0;
            
            return val;
        }

        private static void OnAaaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as CustomObject;

            Debug.WriteLine("AAA Has chanfged to " + e.NewValue);
            var source = DependencyPropertyHelper.GetValueSource(c, AAAProperty);
            Debug.WriteLine("Source = " + source.BaseValueSource);

        }

        public int AAA
        {
            get { return (int)GetValue(AAAProperty); }
            set { SetValue(AAAProperty, value); }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FunWithXaml
{
    public class RepeaterExtension : MarkupExtension
    {
        public string Text { get; set; }

        public int Times { get; set; }

        public RepeaterExtension()
        {
            Text = "*";
            Times = 3;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Times; i++)
            {
                sb.Append(Text);
            }

            return sb.ToString();
        }
    }
}

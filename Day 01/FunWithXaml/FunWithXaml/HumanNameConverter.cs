using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithXaml
{
    public class HumanNameConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;

            return false;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var str = value as string;

            var parts = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var res = new HumanName();

            try
            {
                res.FirstName = parts[0];
                res.LastName = parts.Length == 2 ? parts[1] : parts[2];
                res.MiddleName = parts.Length > 2 ? parts[1] : "";
            }
            catch
            {
            }

            return res;

        }
    }
}

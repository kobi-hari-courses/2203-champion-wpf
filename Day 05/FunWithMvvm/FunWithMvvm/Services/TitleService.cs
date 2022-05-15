using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMvvm.Services
{
    public class TitleService : ITitleService
    {
        public async Task<string> GetTitle()
        {
            await Task.Delay(2000);
            return "Title from service";
        }
    }
}

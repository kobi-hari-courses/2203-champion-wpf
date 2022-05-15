using FunWithMvvm.Services;
using MvvmTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMvvm.Components.Shell
{
    public class ShellVm: BindableBase
    {
        private string _title = "";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private ITitleService? _titleService = null;


        public ShellVm()
        {

        }

        public ShellVm(ITitleService titleService)
        {
            _titleService = titleService;
            Init();
        }

        private async void Init()
        {
            Title = "Please Wait...";
            Title = await _titleService!.GetTitle();
        }
    }
}

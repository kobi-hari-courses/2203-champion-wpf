using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmTools
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (s, e) => { };

        public bool Set<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
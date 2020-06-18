using System.ComponentModel;

namespace Malinka.Core.Models
{
    public abstract class BasePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using System.ComponentModel;

namespace SiteHand.Core.ViewModels
{
    // PropertyChanged.Fody will take care of boiler plate code ralted to INotifyPropertyChanged
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsBusy { get; protected set; }
        public string Title { get; protected set; }
    }
}

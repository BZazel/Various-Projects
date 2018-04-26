using System.ComponentModel;

namespace Player
{   
    /// <summary>
    /// Base "Property changed" handler, for properties in every view model
    /// </summary>
    public class BaseViewModel  :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender,e ) => { };

        public void OnPropertyChanged (string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

       
    }
}

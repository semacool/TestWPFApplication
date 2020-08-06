using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WorkersDep.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

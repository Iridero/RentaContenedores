using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentaContenedores.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Vista { get; set; }

        public ICommand CambiarVista { get; set; }
        
        public MainViewModel()
        {
            CambiarVista = new RelayCommand<string>(cambiarVista);
            Vista = "contenedor";
            Raise();
        }

        private void cambiarVista(string vista) {
            Vista = vista;
            Raise();
        }

        void Raise(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentaContenedores.Data;

namespace RentaContenedores.ViewModels
{
    public enum CRUD { Create, Read, Update, Delete };
    public class ContenedoresViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<Contenedor> Contenedores { get; set; }
        public Contenedor Contenedor { get; set; }
        public CRUD Operacion { get; set; }
        public ICommand NuevoCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ContenedoresViewModel()
        {
            ContenedoresDataContext context=new ContenedoresDataContext();
            Contenedores = new ObservableCollection<Contenedor>(context.Contenedores);
            Operacion = CRUD.Read;
        }



        void RaiseEvent(string? name = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

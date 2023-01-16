using CreacionVentanas.Servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CreacionVentanas
{
    class MainWindowVM : ObservableObject
    {
        private ServicioNavegacion sn;
        public RelayCommand AbrirCommand { get; }

        public RelayCommand UC1Command { get; }
        public RelayCommand UC2Command { get; }
        public RelayCommand CambiaCommand { get; }

        private UserControl contenidoMostrar;

        public UserControl ContenidoMostrar
        {
            get { return contenidoMostrar; }
            set { SetProperty(ref contenidoMostrar, value); }
        }


        public MainWindowVM()
        {
            AbrirCommand = new RelayCommand(AbrirVentanaHija);
            UC1Command = new RelayCommand(CargarUC1);
            UC2Command = new RelayCommand(CargarUC2);
            CambiaCommand = new RelayCommand(CambiarTexto);
            sn = new ServicioNavegacion();

            WeakReferenceMessenger.Default.Register<MainWindowVM, TextoInicialRequestMessage>
                (this, (r,m) => 
                {
                    m.Reply("Que la fuerza te acompañe");
                });
        }

        public void AbrirVentanaHija()
        {
            sn.AbrirVentanaHija();
        }

        public void CargarUC1()
        {
            ContenidoMostrar = sn.CargaUC1();
        }

        public void CargarUC2()
        {
            ContenidoMostrar = sn.CargaUC2();
        }

        public void CambiarTexto()
        {
            WeakReferenceMessenger.Default.Send(new CambiarTextoValueChangeMessage("Este es el camino"));
        }
    }
}

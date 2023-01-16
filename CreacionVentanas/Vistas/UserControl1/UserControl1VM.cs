using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionVentanas
{
    class UserControl1VM : ObservableRecipient
    {
        public string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
            set { SetProperty(ref mensaje, value); }
        }

        public UserControl1VM()
        {
            Mensaje = WeakReferenceMessenger.Default.Send<TextoInicialRequestMessage>();

            WeakReferenceMessenger.Default.Register<CambiarTextoValueChangeMessage>
                (this, (r,m) => {
                    Mensaje = m.Value;
                });
        }
    }
}

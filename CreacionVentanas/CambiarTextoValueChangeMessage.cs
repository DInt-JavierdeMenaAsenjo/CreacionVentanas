using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionVentanas
{
    public class CambiarTextoValueChangeMessage : ValueChangedMessage<String>
    {
        public CambiarTextoValueChangeMessage(String texto) : base(texto) { }
    }
}

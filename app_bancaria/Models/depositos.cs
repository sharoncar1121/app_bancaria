using System;
using System.Collections.Generic;
using System.Text;

namespace app_bancaria.Models
{
    [Serializable]
    public class depositos
    {
        public double cant_deposito { get; set; }
        public DateTime fecha_deposito { get; set; }

        public string toString()
        {
            return "El deposito de cantidad: " + cant_deposito + "realizado con exito la" +
                " fecha: " + fecha_deposito.ToString("MM-dd-yyyy");
        }
    }

}

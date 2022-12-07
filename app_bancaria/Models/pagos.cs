using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace app_bancaria.Models
{
    [Serializable]
    public class pagos: retiros
    {
        public string detalles_pago { get; set; }
        public double cant_pago { get; set; }
        public DateTime fecha_pago { get; set; }

        public new string toString()
        {
            return "El pago: " + cant_pago + "realizado con exito la" +
                " fecha: " + fecha_pago.ToString("MM-dd-yyyy");
        }
    }
}

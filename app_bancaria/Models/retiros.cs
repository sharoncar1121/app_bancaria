using System;
using System.Collections.Generic;
using System.Text;

namespace app_bancaria.Models
{
    [Serializable]
    public class retiros : depositos
    {
        public double cant_retiro { get; set; }
        public DateTime fecha_retiro { get; set; }

        public new string toString()
        {
            return "El retiro de cantidad: " + cant_retiro+ "realizado con exito la" +
                " fecha: " + fecha_retiro.ToString("MM-dd-yyyy");
        }
    }
}

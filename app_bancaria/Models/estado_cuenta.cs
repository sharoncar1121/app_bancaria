using System;
using System.Collections.Generic;
using System.Text;

namespace app_bancaria.Models
{
    [Serializable]
    public class estado_cuenta: pagos
    {
        public double Monto_inicial { get; set; }
        public double Monto_final { get; set; }
        public DateTime fecha_estado { get; set; }

        public void calcula_estado()
        {
            Monto_final = Monto_inicial + cant_deposito - (cant_retiro+cant_pago);
        }

        public new string toString()
        {

            return "Su monto final es: " + Monto_final;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace app_bancaria.Models
{
    [Serializable]
    public class usuario
    {

        public string nombre { get; set; }

        public string ID_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; }

        public ObservableCollection<depositos> lista_deposito { get; set; } = new ObservableCollection<depositos>();
        public ObservableCollection<retiros> lista_retiro { get; set; } = new ObservableCollection<retiros>();
        public ObservableCollection<pagos> lista_pago { get; set; } = new ObservableCollection<pagos>();

        public ObservableCollection<estado_cuenta> lista_estado { get; set; } = new ObservableCollection<estado_cuenta>();
        public string toString()
        {

            return "Ha ingresado el usuario: " + nombre + "con ID de usuario: "+ ID_usuario+
             "con nombre de usuaruio: "+nombre_usuario+ "con contraseña: "+ password;
        }


    }
}

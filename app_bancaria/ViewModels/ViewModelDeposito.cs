using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using app_bancaria.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace app_bancaria.ViewModels
{
    public class ViewModelDeposito : INotifyPropertyChanged
    {

        public ViewModelDeposito()
        {

            AbrirArchivo();


            GuardarDeposito = new Command(() => {

                depositos d = new depositos()
                {
                    cant_deposito = this.cant_deposito,
                    fecha_deposito = this.fecha_deposito,

                };

              
                p.lista_deposito.Add(d);

                //Rutina de Serializacion para guardar el ejercicio de la persona
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Info = "";

                foreach (depositos x in p.lista_deposito)
                {

                    Info += x.toString();

                }

            });


        }

   
        private void AbrirArchivo()
        {

            // Es una estructura 

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                p = (usuario)formatter.Deserialize(archivo);
                archivo.Close();

                Info = "";

                foreach (depositos x in p.lista_deposito)
                {

                    Info += x.toString();

                }

            }
            catch (Exception d)
            {


            }



        }

        usuario p = new usuario();

        double cant_deposito;

        public double Cant_deposito
        {
            get => cant_deposito;
            set
            {
                cant_deposito = value;
                var arg = new PropertyChangedEventArgs(nameof(Cant_deposito));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        DateTime fecha_deposito = DateTime.Today;

        public DateTime Fecha_deposito
        {
            get => fecha_deposito;
            set
            {
                fecha_deposito = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha_deposito));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        DateTime fechaMin = DateTime.Today;

        public DateTime FechaMin
        {
            get => fechaMin;
            set
            {

                fechaMin = value;
                var arg = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string Info;

        public string info
        {
            get => Info;
            set
            {

                Info = value;
                var arg = new PropertyChangedEventArgs(nameof(info));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public Command GuardarDeposito { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

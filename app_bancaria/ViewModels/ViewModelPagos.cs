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
    public class ViewModelPagos : INotifyPropertyChanged
    {

        public ViewModelPagos()
        {

            AbrirArchivo();


            GuardarPago = new Command(() => {

                 pagos g = new pagos ()
                {
                    cant_pago = this.cant_pago,
                    fecha_pago = this.fecha_pago,
                    detalles_pago=this.detalles_pago

                };


                p.lista_pago.Add(g);

                //Rutina de Serializacion para guardar el ejercicio de la persona
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Info = "";

                foreach (depositos x in p.lista_pago)
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

                foreach (pagos x in p.lista_pago)
                {

                    Info += x.toString();

                }

            }
            catch (Exception e)
            {


            }



        }

        usuario p = new usuario();

        double cant_pago;

        public double Cant_pago
        {
            get => cant_pago;
            set
            {
                cant_pago = value;
                var arg = new PropertyChangedEventArgs(nameof(Cant_pago));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string detalles_pago;

        public string Detalles_pago
        {
            get => Detalles_pago;
            set
            {
                detalles_pago = value;
                var arg = new PropertyChangedEventArgs(nameof(Detalles_pago));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        DateTime fecha_pago = DateTime.Today;

        public DateTime Fecha_pago
        {
            get => fecha_pago;
            set
            {
                fecha_pago = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha_pago));
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

        TimeSpan horaInicio;

        public TimeSpan HoraInicio
        {
            get => horaInicio;
            set
            {

                horaInicio = value;
                var arg = new PropertyChangedEventArgs(nameof(HoraInicio));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        TimeSpan horaFin;

        public TimeSpan HoraFin
        {
            get => horaFin;
            set
            {

                horaFin = value;
                var arg = new PropertyChangedEventArgs(nameof(HoraFin));
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


        public Command GuardarPago { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

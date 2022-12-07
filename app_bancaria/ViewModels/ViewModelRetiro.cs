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
    public class ViewModelRetiro : INotifyPropertyChanged
    {

        public ViewModelRetiro()
        {

            AbrirArchivo();


            GuardarRetiro = new Command(() => {

                retiros r = new retiros()
                {
                    cant_retiro = this.cant_retiro,
                    fecha_retiro = this.fecha_retiro,

                };


                p.lista_retiro.Add(r);

                //Rutina de Serializacion para guardar el ejercicio de la persona
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Info = "";

                foreach (depositos x in p.lista_retiro)
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

                foreach (depositos x in p.lista_retiro)
                {

                    Info += x.toString();

                }

            }
            catch (Exception d)
            {


            }



        }

        usuario p = new usuario();

        double cant_retiro;

        public double Cant_retiro
        {
            get => cant_retiro;
            set
            {
                cant_retiro = value;
                var arg = new PropertyChangedEventArgs(nameof(Cant_retiro));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        DateTime fecha_retiro = DateTime.Today;

        public DateTime Fecha_retiro
        {
            get => fecha_retiro;
            set
            {
                fecha_retiro = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha_retiro));
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


        public Command GuardarRetiro { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

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
    public class ViewModelCuenta : INotifyPropertyChanged
    {

        public ViewModelCuenta()
        {

            AbrirArchivo();


            CrearCuenta = new Command(() => {

                estado_cuenta c1 = new estado_cuenta()
                {
                    Monto_inicial = this.Monto_inicial,
                    fecha_estado = this.fecha_estado,
                    Monto_final=this.Monto_final

                };

                c1.calcula_estado();
                p.lista_estado.Add(c1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

                Info = "";

                foreach (estado_cuenta c in p.lista_estado)
                {

                    Info += c.toString();

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

                foreach (estado_cuenta x in p.lista_estado)
                {

                    Info += x.toString();

                }


            }
            catch (Exception e)
            {


            }



        }


        string info;

        public string Info
        {

            get => info;
            set
            {

                info = value;
                var args = new PropertyChangedEventArgs(nameof(Info));
                PropertyChanged?.Invoke(this, args);

            }

        }

        usuario p = new usuario();

        double Monto_inicial;

        public double monto_inicial
        {

            get => Monto_inicial;
            set
            {

                Monto_inicial = value;
                var args = new PropertyChangedEventArgs(nameof(monto_inicial));
                PropertyChanged?.Invoke(this, args);

            }

        }

        double Monto_final;
        public double monto_final
        {

            get => Monto_final;
            set
            {

                Monto_final = value;
                var args = new PropertyChangedEventArgs(nameof(monto_final));
                PropertyChanged?.Invoke(this, args);

            }

        }


        DateTime fecha_estado = DateTime.Today;

        public DateTime Fecha_estado
        {

            get => fecha_estado;
            set
            {

                fecha_estado = value;
                var args = new PropertyChangedEventArgs(nameof(Fecha_estado));
                PropertyChanged?.Invoke(this, args);

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

        public Command CrearCuenta { get; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}


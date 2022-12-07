using app_bancaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace app_bancaria.ViewModels
{
    public class ViewModelUsuario : INotifyPropertyChanged
    {
        public ViewModelUsuario()
        {

            AbrirArchivo();


            CrearUsuario = new Command(() => {

                p = new usuario()
                {

                    nombre = this.nombre,
                    ID_usuario = this.ID_usuario,
                    nombre_usuario = this.nombre_usuario,
                    password = this.password

                };
                //Rutina de Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "info.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();

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

                Nombre = p.nombre;
                iD_usuario = p.ID_usuario;
                Nombre_usuario = p.nombre_usuario;
                Password = p.password;
            }
            catch (Exception e)
            {


            }



        }

        usuario p = new usuario();

        string nombre;

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }

      
        string ID_usuario;

        public string iD_usuario
        {
            get => ID_usuario;
            set
            {
                ID_usuario = value;
                var arg = new PropertyChangedEventArgs(nameof(iD_usuario));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                var arg = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string nombre_usuario;

        public string Nombre_usuario
        {
            get => nombre_usuario;
            set
            {
                password = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre_usuario));
                PropertyChanged?.Invoke(this, arg);

            }
        }




        public Command CrearUsuario { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

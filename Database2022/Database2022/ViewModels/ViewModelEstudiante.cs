using Database2022.Models;
using Database2022.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{
    public class ViewModelEstudiante:BaseViewModel
    {


        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { SetValue(ref this.apellido, value); }
        }

        private int idEstudiante;
        public int IdEstudiante
        {
            get { return idEstudiante; }
            set { SetValue(ref this.idEstudiante, value); }
        }

        private string grado;
        public string Grado
        {
            get { return grado; }
            set { SetValue(ref this.grado, value); }
        }

        private string seccion;
        public string Seccion
        {
            get { return seccion; }
            set { SetValue(ref this.seccion, value); }
        }


        private List<Estudiante> estudiantes;
        public List<Estudiante> Estudiantes
        {
            get { return this.estudiantes; }
            set { SetValue(ref this.estudiantes, value); }
        }

        private Estudiante estudiante;
        public Estudiante Estudiante
        {
            get { return this.estudiante; }
            set { SetValue(ref this.estudiante, value); }
        }

        //public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectOneCommand { get; set; }
        public ViewModelEstudiante()
        {
            EstudianteService service = new EstudianteService();
            Estudiantes = service.Get();

            InsertCommand = new Command(() =>
            {
                EstudianteService service = new EstudianteService();
                if (IdEstudiante != 0)
                {
                    //Console.WriteLine(IdEstudiante);
                    service.UpdateEstudiante(new Estudiante { Nombre = Nombre, Apellido = Apellido, EstudianteId = IdEstudiante,Grado=Grado,Seccion=Seccion }, IdEstudiante);

                    Nombre = "";
                    Apellido = "";
                    Grado = "";
                    Seccion = "";
                    IdEstudiante = 0;
                }
                else
                {
                    int newEstudentId = service.Get().Count + 1;
                    service.Create(new Estudiante { Nombre = Nombre, Apellido = Apellido, Grado = Grado, Seccion = Seccion, EstudianteId = newEstudentId });
                    Nombre = "";
                    Apellido = "";
                    Grado = "";
                    Seccion = "";
                    IdEstudiante = 0;
                }
                Estudiantes = service.Get();
            });

            SelectOneCommand = new Command<int>(execute: (int parameter) =>
            {
                EstudianteService service = new EstudianteService();
                int ide = parameter;
                Estudiante = service.GetById(ide);
                Nombre = Estudiante.Nombre;
                Apellido = Estudiante.Apellido;
                Grado = Estudiante.Grado;
                Seccion = Estudiante.Seccion;
                IdEstudiante = Estudiante.EstudianteId;
                //Console.WriteLine(IdPerson);
            });

            DeleteCommand = new Command<int>(execute: (int parameter) =>
            {
                EstudianteService service = new EstudianteService();
                int ide = parameter;
                service.DeleteEstudiante(ide);
                Estudiantes = service.Get();
            });
        }


    }

}

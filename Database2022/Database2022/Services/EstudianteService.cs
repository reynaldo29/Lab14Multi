using Database2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database2022.Services
{
    internal class EstudianteService
    {
        private readonly AppDbContext _context;

        public EstudianteService() => _context = App.GetContext();


        public bool Create(Estudiante item)
        {
            try
            {
                //EntityFrameworkCore
                _context.Estudiante.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Estudiante> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.Estudiante.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Estudiante> Get()
        {
            return _context.Estudiante.ToList();
        }


        public Estudiante GetById(int id)
        {
            return _context.Estudiante.Where(x => x.EstudianteId == id).FirstOrDefault();
        }

        public bool UpdateEstudiante(Estudiante Estudiante, int id)
        {
            try
            {
                var model = GetById(id);
                model.Nombre = Estudiante.Nombre;
                model.Apellido = Estudiante.Apellido;
                model.Grado = Estudiante.Grado;
                model.Seccion = Estudiante.Seccion;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteEstudiante(int id)
        {
            try
            {
                var model = GetById(id);
                _context.Remove(model);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database2022
{
    public class PersonService
    {
        private readonly AppDbContext _context;

        public PersonService() => _context = App.GetContext();

        
        public bool Create(Person item)
        {
            try
            {
                //EntityFrameworkCore
                _context.People.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool CreateRange(List<Person> items)
        {
            try
            {
                //EntityFrameworkCore
                _context.People.AddRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Person> Get()
        {
            return _context.People.ToList();
        }


        public List<Person> GetByText(string text)
        {
            return _context.People.Where(x => x.FirstName.Contains(text) || x.LastName.Contains(text)).ToList();
        }

        public Person GetById(int id)
        {
            return _context.People.Where(x => x.PersonId == id).FirstOrDefault();
        }

        public bool UpdatePerson(Person person, int id)
        {
            try
            {
                var model = GetById(id);
                model.LastName = person.LastName;
                model.FirstName = person.FirstName;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePerson(int id)
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

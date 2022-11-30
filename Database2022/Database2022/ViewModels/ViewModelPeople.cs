using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Database2022.ViewModels
{
    public class ViewModelPeople: BaseViewModel
    {
        private string color;
        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }


        private string filter;
        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value); }
        }


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetValue(ref this.firstName, value); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetValue(ref this.lastName, value); }
        }

        private int idPerson;
        public int IdPerson
        {
            get { return idPerson; }
            set { SetValue(ref this.idPerson, value); }
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }

        private Person person;
        public Person Person
        {
            get { return this.person; }
            set { SetValue(ref this.person, value); }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SelectOneCommand { get; set; }
        public ViewModelPeople()
        {
            PersonService service = new PersonService();
            People = service.Get();

            SearchCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                People = service.Get();
            });

            InsertCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                if (IdPerson != 0)
                {
                    Console.WriteLine(IdPerson);
                    service.UpdatePerson(new Person { FirstName=FirstName, LastName = LastName, PersonId=IdPerson}, IdPerson);

                    FirstName = "";
                    LastName = "";
                    IdPerson = 0;
                }
                else
                {
                    int newPersonId = service.Get().Count + 1;
                    service.Create(new Person { FirstName = FirstName, LastName = LastName, PersonId = newPersonId });
                    FirstName = "";
                    LastName = "";
                }
                People = service.Get();
            });

            SelectOneCommand = new Command<int>(execute: (int parameter) =>
            {
                PersonService service = new PersonService();
                int ide = parameter;
                Person = service.GetById(ide);
                FirstName = Person.FirstName;
                LastName = Person.LastName;
                IdPerson = Person.PersonId;
                //Console.WriteLine(IdPerson);
            });

            DeleteCommand = new Command<int>(execute: (int parameter) =>
            {
                PersonService service = new PersonService();
                int ide = parameter;
                service.DeletePerson(ide);
                People = service.Get();
            });
        }


    }
}

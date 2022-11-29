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



        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { SetValue(ref this.people, value); }
        }


        public ICommand SearchCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ViewModelPeople()
        {

            SearchCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                People = service.Get();
              

            });

            InsertCommand = new Command(() =>
            {
                PersonService service = new PersonService();
                int newPersonId = service.Get().Count + 1;
                service.Create(new Person { FirstName = FirstName, LastName = LastName, PersonId = newPersonId });
            });

            DeleteCommand = new Command<int>(execute: (int parameter) =>
            {
                PersonService service = new PersonService();
                int ide = parameter;
                service.DeletePerson(ide);
            });
        }


    }
}

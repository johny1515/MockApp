using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
    public class PersonRepository : IPersonRepository 
    {
    private List<Person> Lperson;
        public PersonRepository(){
            Lperson = new List<Person>();
            Lperson.Add(new Person("Arek", "Kowal", "Mietniwo", 26));
            Lperson.Add(new Person("Tomasz", "Brzostowski", "Opacz", 5));
            Lperson.Add(new Person("Mrek", "Marecki", "Wawa", 21));
            var x = Lperson.First();
        }
        
        public List<Person> AllPerson(int age)
        {
            
            var oAdultPersonsList = from Person in Lperson
                                    where Person.Age >= age
                                    orderby Person.Age
                                    select Person;

            return oAdultPersonsList.ToList();
        }
        public List<Person> AdultPerson()
        {
           
            var oAdultPersonsList = from Person in Lperson
                                    where Person.Age >18
                                    orderby Person.Age
                                    select Person;

            return oAdultPersonsList.ToList();
        }
    }
}

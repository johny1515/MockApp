using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WinApp
{
    public class ServiceOfPerson 
    {
        private IPersonRepository Repository;
        
        public ServiceOfPerson(IPersonRepository Repo)
        {
            this.Repository = Repo;
        }

        public List<Person> FindByName(string name)
        {

            List<Person> ListOfAllPerson = this.Repository.AllPerson(0);
            var FirstNameList = from Person in ListOfAllPerson
                                    where Person.FirstName ==name
                                    orderby Person.FirstName
                                    select Person;

            return FirstNameList.ToList();
        
        }
        public List<Person> FindByAge(int age)
        {
            List<Person> ListFindByAge = this.Repository.AdultPerson();
            var oAdultPersonsList = from Person in ListFindByAge
                                    where Person.Age >= age
                                    orderby Person.Age
                                    select Person;

            return oAdultPersonsList.ToList();
        }
        public List<Person> AdultPerson()
        {
            List<Person> ListFindAdult = this.Repository.AdultPerson();
            return ListFindAdult;
        }

    }
}

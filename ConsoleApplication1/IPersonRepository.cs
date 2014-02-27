using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
    public interface IPersonRepository 
    {

       List<Person> AllPerson(int age);
       List<Person> AdultPerson();
       
       }
        
    }


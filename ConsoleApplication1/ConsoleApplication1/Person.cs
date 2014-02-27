using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApp
{
    public class Person 
    {
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age{get; set;}
       public Person() { }
       public Person(string firstName, string lastName, string address, int age)
       {
           FirstName = firstName;
           LastName = lastName;
           Address = address;
           Age = age;

       }
     
      
    }
    

}

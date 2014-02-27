using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinApp;
using Moq;
using System.Linq; 
using System.Collections.Generic;



namespace WinTest
{
    [TestClass]
    public class UnitTest1 
    {
        //public const int age = 18;
        public static Mock<IPersonRepository> ListPerson(int age)
        {
            
            List<Person> ListOfPerson = new List<Person>();
            if (age <= 12) ListOfPerson.Add(new Person("MockTomek", "MockTomik", "MockLeszno", 12));
            if (age <= 20) ListOfPerson.Add(new Person("MockMirek", "MockMirkowiak", "MockOpoczno", 20));
            if (age <= 18) ListOfPerson.Add(new Person("MockBartek", "MockMarecki", "MockMielec", 18));
            
           // List<Person> oFoundPersonsList = ListOfPerson.FindAll(oElement => oElement.FirstName.Equals("MockTomek"));
            Mock<IPersonRepository> mockPerson = new Mock<IPersonRepository>();
            mockPerson.Setup(mr => mr.AllPerson(age)).Returns(ListOfPerson);
            mockPerson.Setup(mr => mr.AdultPerson()).Returns(ListOfPerson);
            return mockPerson;
        }

        public UnitTest1() 
        {
            
            
        }
        

        [TestMethod]
        public void TestMethod1()
        {
            List<Person> testListOfPerson =ListPerson(11).Object.AllPerson(11);
            Assert.AreEqual(testListOfPerson.Count, 3);
            var x = testListOfPerson.First();
            Person p1 = testListOfPerson.First();
            Assert.AreEqual("MockTomek",p1.FirstName);
            Assert.AreEqual("MockTomik",p1.LastName);
            Assert.AreEqual(12, p1.Age);
            Assert.AreNotEqual("MockMirek", p1.FirstName);
            Assert.AreNotSame("MockMirek", p1.FirstName);
            Assert.AreSame("MockTomik", p1.LastName);
            
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<Person> testListOfPerson = ListPerson(18).Object.AdultPerson();
            Person p1 = testListOfPerson.First();
            Assert.AreNotEqual("MockTomek", p1.FirstName);
            Assert.AreNotSame("MockTomik", p1.FirstName);
            Assert.AreSame("MockMirkowiak", p1.LastName);
           //Assert.Fail();
            Assert.IsFalse(false);
            Assert.IsInstanceOfType(p1,typeof(Object));
            Assert.IsNotInstanceOfType(p1, typeof(int));
            Assert.IsNotNull(p1);
            //Assert.IsNull(p1.Address);
            //Assert.IsTrue(true);
            Assert.ReplaceNullChars(p1.Address);
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<Person> testListOfPerson = ListPerson(18).Object.AdultPerson();
            Person p1 = testListOfPerson.First();
            Assert.AreEqual(testListOfPerson.Count, 2);
            Assert.AreEqual("MockMirek", p1.FirstName);
            Assert.AreEqual("MockMirkowiak", p1.LastName);
            Assert.AreEqual(p1.Age>=18,true);
            Assert.AreNotEqual("MockTomek", p1.FirstName);
            Assert.AreNotSame("MockTomik", p1.FirstName);
            Assert.AreSame("MockMirkowiak", p1.LastName);
           

        }
    }
}

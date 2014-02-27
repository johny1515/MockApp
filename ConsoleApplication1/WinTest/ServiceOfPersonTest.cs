using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using WinApp;
using System.Collections.Generic;

namespace WinTest
{
    [TestClass]
    public class ServiceOfPersonTest
    {
        public static Mock<IPersonRepository> ListPerson(int age)
        {

            List<Person> ListOfPerson = new List<Person>();
            if (age <= 12) ListOfPerson.Add(new Person("MockTomek", "MockTomik", "MockLeszno", 12));
            if (age <= 22) ListOfPerson.Add(new Person("MockMirek", "MockMirkowiak", "MockOpoczno", 22));
            if (age <= 21) ListOfPerson.Add(new Person("MockBartek", "MockMarecki", "MockMielec", 21));

            // List<Person> oFoundPersonsList = ListOfPerson.FindAll(oElement => oElement.FirstName.Equals("MockTomek"));
            Mock<IPersonRepository> mockPerson = new Mock<IPersonRepository>();
            mockPerson.Setup(mr => mr.AllPerson(age)).Returns(ListOfPerson);
            mockPerson.Setup(mr => mr.AdultPerson()).Returns(ListOfPerson);
            return mockPerson;
        }
        [TestMethod]
        public void FindByNameMarek()
        {
            Mock<IPersonRepository> MockRepo = ListPerson(0);
            ServiceOfPerson Service = new ServiceOfPerson(MockRepo.Object);
            List<Person> ListOfPerson = Service.FindByName("Marek");
            Assert.AreEqual(0, ListOfPerson.Count);

        }
        [TestMethod]
        public void FindByNameFirstMockTomek()
        {
            Mock<IPersonRepository> MockRepo = ListPerson(0);
            ServiceOfPerson Service = new ServiceOfPerson(MockRepo.Object);
            List<Person> ListOfPerson = Service.FindByName("MockTomek");
            Assert.AreEqual(1, ListOfPerson.Count);
            Person p1 = ListOfPerson.First();
            Assert.AreEqual("MockTomek", p1.FirstName);

        }
        [TestMethod]
        public void FindPersonByAge20()
        {
            Mock<IPersonRepository> MockRepo = ListPerson(20);
            ServiceOfPerson Service = new ServiceOfPerson(MockRepo.Object);
            List<Person> ListOfPerson = Service.FindByAge(20);
            Assert.AreEqual(2, ListOfPerson.Count);
            Person p1 = ListOfPerson.First();
            Assert.AreEqual("MockBartek", p1.FirstName);
            Assert.AreEqual(true, p1.Age >= 20);
        }
        [TestMethod]
        public void FindAdultPerson()
        {
            Mock<IPersonRepository> MockRepo = ListPerson(18);
            ServiceOfPerson Service = new ServiceOfPerson(MockRepo.Object);
            List<Person> ListOfPerson = Service.AdultPerson();
            Assert.AreEqual(2, ListOfPerson.Count);
            List<Person> p1 = ListOfPerson;
            Assert.AreEqual(p1, p1);
            

        }
        [TestMethod]
        public void CheckListIsNotNull()
        {
            Mock<IPersonRepository> MockRepo = ListPerson(18);
            ServiceOfPerson Service = new ServiceOfPerson(MockRepo.Object);
            List<Person> ListOfPerson = Service.AdultPerson();
            List<Person> p1 = ListOfPerson;
            Assert.IsNotNull(p1);

        }
    }
}

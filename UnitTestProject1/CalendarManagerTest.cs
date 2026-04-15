using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager;

namespace UnitTestProject1
{
    [TestClass]
    public class CalendarManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveEvent()
        {
            //Act
            new CalendarManager().RemoveEvent(null);
        }

        [TestMethod]
        public void SaveEvent()
        {
            //Arrenge
            var CalendarManager = new CalendarManager();
            CalendarManager.AddEvent(new Event(DateTime.Now, "Test"));

            //Act
            CalendarManager.SaveEvents();

            //Assert
            Assert.IsTrue(File.Exists("events.txt"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullВEventError()
        {
            // Act
            new CalendarManager().AddEvent(null);
        }

        [TestMethod]
        public void LoadEvents()
        {
            //Arrenge
            var CalendarManager = new CalendarManager();
            CalendarManager.AddEvent(new Event(DateTime.Now, "Test"));

            //Act
            CalendarManager.LoadEvents();

            //Assert
            Assert.IsTrue(File.Exists("events.txt"));
        }

    }
}

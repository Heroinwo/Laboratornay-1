using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void IsDateInDaylightSavingTimeForCurrentTimeZone()
        {
            //Arrange
            var Date = new DateTime(2026, 04, 9);

            //Act
            var result = Date.IsDaylightSavingTime();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToString_ReturnsStringRepresentationOfDate()
        {
            //Arrange
            var Date = new DateTime(2025, 09, 13);

            //Act
            var result = Date.ToString();

            //Assert
            StringAssert.Contains(result, "13.09.2025");
        }

        [TestMethod]
        public void Description_CanBeEmptyString()
        {
            // Arrange
            var Description = new ProductManager.Event(DateTime.Now, "");

            // Act
            var result = Description.Description;

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Description_MayHaveComment()
        {
            // Arrange
            var Description = new ProductManager.Event(new DateTime(2006, 09, 13), "Моё день рождение");

            // Act
            var result = Description.Description;

            // Assert
            Assert.AreEqual(result, "Моё день рождение");
        }

        [TestMethod]
        public void ToString_WhenDescriptionIsEmpty_ReturnsEmptyString()
        {
            // Arrange
            var Description = new ProductManager.Event(DateTime.Now, "");

            // Act
            var result = Description.ToString();

            // Assert
            StringAssert.Contains(result, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotChooseNegativeNumber()
        {
            //Act
            new DateTime(2006, -09, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotChooseZeros()
        {
            //Act
            new DateTime(0000, 00, 00);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotSelectMoreThan31()
        {
            //Act
            new DateTime(2026, 04, 32);
        }
    }
}

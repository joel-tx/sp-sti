using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryAddressTest : AbstractRepositoryTest
    {
        private Address address;

        [TestMethod]
        public void ShouldInsertAddressWhenDBConnectionContextIsValid()
        {
            CreateAddress();
            _spacePlanningUnitOfWork.AddressRepository.Add(address);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AddressRepository.GetById(address.AddressId) != null);
        }

        [TestMethod]
        public void ShouldDeleteAddressWhenDBConnectionContextIsValid()
        {
            CreateAddress();
            _spacePlanningUnitOfWork.AddressRepository.Add(address);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AddressRepository.GetById(address.AddressId) != null);
            _spacePlanningUnitOfWork.AddressRepository.Delete(address);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AddressRepository.GetById(address.AddressId) == null);
        }

        [TestMethod]
        public void ShouldUpdateAddressWhenDBConnectionContextIsValid()
        {
            CreateAddress();
            string newAddress = "New Street";
            _spacePlanningUnitOfWork.AddressRepository.Add(address);
            _spacePlanningUnitOfWork.Save();
            address = _spacePlanningUnitOfWork.AddressRepository.GetById(address.AddressId);
            address.AddressLine1 = newAddress;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(newAddress, _spacePlanningUnitOfWork.AddressRepository.
                GetById(address.AddressId).AddressLine1);
        }

        [TestMethod]
        public void ShouldGetAddressWhenDBConnectionContextIsValid()
        {
            CreateAddress();
            _spacePlanningUnitOfWork.AddressRepository.Add(address);
            _spacePlanningUnitOfWork.Save();
            address = _spacePlanningUnitOfWork.AddressRepository.GetById(address.AddressId);
            Assert.IsNotNull(address);
        }

        private void CreateAddress()
        {
            address = new Address()
            {
                AddressId = Guid.NewGuid(),
                AddressLine1 = "Address 1",
                AddressLine2 = "Address 2",
                City = "cbba",
                Country = "Bolivia",
                PostalCode = "+591",
                Region = "",
                State = "new State"
            };
        }
    }
}

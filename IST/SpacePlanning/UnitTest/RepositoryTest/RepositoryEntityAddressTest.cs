using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryEntityAddressTest : AbstractRepositoryTest
    {
        private EntityAddress bisaAddress;

        [TestMethod]
        public void ShouldInsertEntityAddressWhenDBContextIsValid()
        {
            CreateBankLocations();
            _spacePlanningUnitOfWork.EntityAddressRepository.Add(bisaAddress);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityAddressRepository.GetById(bisaAddress.AddressId,
                bisaAddress.EntityId) != null);
        }

        [TestMethod]
        public void ShouldDeleteEntityAddressWhenDBContextIsValid()
        {
            CreateBankLocations();
            _spacePlanningUnitOfWork.EntityAddressRepository.Add(bisaAddress);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityAddressRepository.GetById(bisaAddress.AddressId,
                bisaAddress.EntityId) != null);
            _spacePlanningUnitOfWork.EntityAddressRepository.Delete(bisaAddress);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElemenUserRepository.GetById(bisaAddress.AddressId, 
                bisaAddress.EntityId) == null);
        }

        [TestMethod]
        public void ShouldUpdateEntityAddressWhenDBContextIsValid()
        {
            CreateBankLocations();
            _spacePlanningUnitOfWork.EntityAddressRepository.Add(bisaAddress);            
            Entity bisaBank = bisaAddress.Entity;
            Address newAddress = new Address()
             {
                AddressId = Guid.NewGuid(),
                AddressLine1 = "New Address 1",
                AddressLine2 = "New Address 2",
                City = "Sucre",
                Country = "Bolivia",
                PostalCode = "+591",
                Region = "",
                State = "new State"
            };
            
            _spacePlanningUnitOfWork.AddressRepository.Add(newAddress);          
            _spacePlanningUnitOfWork.EntityAddressRepository.Delete(bisaAddress);
            EntityAddress bisalocationRecoleta = new EntityAddress()
            {
                Address = newAddress,
                AddressId = newAddress.AddressId,
                Entity = bisaBank,
                EntityId = bisaBank.EntityId
            };

            _spacePlanningUnitOfWork.EntityAddressRepository.Add(bisalocationRecoleta);
            _spacePlanningUnitOfWork.Save();
            EntityAddress newBisaAddress = _spacePlanningUnitOfWork.EntityAddressRepository.GetById(bisalocationRecoleta.AddressId,
                bisalocationRecoleta.EntityId);
            Assert.AreEqual("New Address 1", _spacePlanningUnitOfWork.EntityAddressRepository.GetById(newBisaAddress.AddressId, 
                newBisaAddress.EntityId).Address.AddressLine1);
            Assert.AreEqual("New Address 2", _spacePlanningUnitOfWork.EntityAddressRepository.GetById(newBisaAddress.AddressId, 
                newBisaAddress.EntityId).Address.AddressLine2);
        }

        [TestMethod]
        public void ShouldGetEntityAddressWhenDBContextIsValid()
        {
            CreateBankLocations();
            _spacePlanningUnitOfWork.EntityAddressRepository.Add(bisaAddress);
            _spacePlanningUnitOfWork.Save();
            bisaAddress = _spacePlanningUnitOfWork.EntityAddressRepository.GetById(bisaAddress.AddressId, 
                bisaAddress.EntityId);
            Assert.IsNotNull(bisaAddress);
        }

        private void CreateBankLocations()
        {
            EntityType banks = new EntityType()
            {
                EntityTypeId = Guid.NewGuid(),
                Name = "Banks",
                Description = "Banks organizations"

            };
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            Entity bisaBank = new Entity()
            {
                EntityId = Guid.NewGuid(),
                Name = "BISA Bank",
                Description = "BISA Bank",
                EntityTypeId = banks.EntityTypeId

            };
            _spacePlanningUnitOfWork.EntityRepository.Add(bisaBank);
            _spacePlanningUnitOfWork.Save();

            Address address = new Address()
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
            _spacePlanningUnitOfWork.AddressRepository.Add(address);
            bisaAddress = new EntityAddress()
            {
                Address = address,
                AddressId = address.AddressId,
                Entity = bisaBank,
                EntityId = bisaBank.EntityId
            };
        }
    }
}

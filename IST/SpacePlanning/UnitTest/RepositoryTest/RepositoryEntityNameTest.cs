using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryEntityNameTest : AbstractRepositoryTest
    {
        private EntityName ownerBank;

        [TestMethod]
        public void ShouldInsertEntityNameWhenDBContextIsValid()
        {
            CreateOwnersBisa();
            _spacePlanningUnitOfWork.EntityNameRepository.Add(ownerBank);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityNameRepository.GetById(ownerBank.NameId, 
                ownerBank.EntityId) != null);
        }

        [TestMethod]
        public void ShouldDeleteEntityNameWhenDBContextIsValid()
        {
            CreateOwnersBisa();
            _spacePlanningUnitOfWork.EntityNameRepository.Add(ownerBank);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityNameRepository.GetById(ownerBank.NameId, 
                ownerBank.EntityId) != null);
            _spacePlanningUnitOfWork.EntityNameRepository.Delete(ownerBank);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityNameRepository.GetById(ownerBank.NameId, 
                ownerBank.EntityId) == null);
        }

        [TestMethod]
        public void ShouldUpdateEntityNameWhenDBContextIsValid()
        {
            CreateOwnersBisa();
            _spacePlanningUnitOfWork.EntityNameRepository.Add(ownerBank);
            Entity bisa = ownerBank.Entity;
            Name newOwner = new Name() { First = "Luis", Middle = "Pedro", Last = "Rios",
                NameId = Guid.NewGuid(), Prefix = "lpr", Suffix = "lpr" };

            _spacePlanningUnitOfWork.NameRepository.Add(newOwner);
            _spacePlanningUnitOfWork.EntityNameRepository.Delete(ownerBank);
            EntityName newOwnerBisa = new EntityName() { Entity = bisa, Name = newOwner};

            _spacePlanningUnitOfWork.EntityNameRepository.Add(newOwnerBisa);
            _spacePlanningUnitOfWork.Save();
            EntityName currentOwner = _spacePlanningUnitOfWork.EntityNameRepository.GetById(newOwnerBisa.NameId , 
                newOwnerBisa.EntityId);
            Assert.AreEqual("Luis", currentOwner.Name.First);
            Assert.AreEqual("Pedro", currentOwner.Name.Middle);
            Assert.AreEqual("Rios", currentOwner.Name.Last);
            Assert.AreEqual("lpr", currentOwner.Name.Prefix);
        }

        [TestMethod]
        public void ShouldGetEntityNameWhenDBContextIsValid()
        {
            CreateOwnersBisa();
            _spacePlanningUnitOfWork.EntityNameRepository.Add(ownerBank);
            _spacePlanningUnitOfWork.Save();
            EntityName ownerBisa = _spacePlanningUnitOfWork.EntityNameRepository.GetById(ownerBank.NameId,
                ownerBank.EntityId);
            Assert.IsNotNull(ownerBisa);
        }

        private void CreateOwnersBisa()
        {
            EntityType banks = new EntityType()
            {
                EntityTypeId = Guid.NewGuid(),
                Name = "Banks",
                Description = "Banks organizations"

            };
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            Entity bisaBank = new Entity()
            {
                EntityId = Guid.NewGuid(),
                Name = "BISA Bank",
                Description = "BISA Bank",
                EntityTypeId = banks.EntityTypeId

            };
            _spacePlanningUnitOfWork.EntityRepository.Add(bisaBank);            
            Name principalOwner = new Name() { First = "Juan", Middle = "Jose" , Last ="Campos",
                NameId = Guid.NewGuid(), Prefix ="jc", Suffix="jc" };
            ownerBank = new EntityName() { Name = principalOwner, Entity = bisaBank };
            _spacePlanningUnitOfWork.Save();

        }
    }
}

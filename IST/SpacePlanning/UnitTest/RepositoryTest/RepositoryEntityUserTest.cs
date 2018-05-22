using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryEntityUserTest : AbstractRepositoryTest
    {
        private EntityUser worker;

        [TestMethod]
        public void ShouldInsertEntityUserWhenDBContextIsValid()
        {
            CreateWorker();
            _spacePlanningUnitOfWork.EntityUserRepository.Add(worker);
            _spacePlanningUnitOfWork.Save();
            Assert.IsNotNull(_spacePlanningUnitOfWork.EntityUserRepository.
                GetById(worker.EntityId, worker.UserId));
        }

        [TestMethod]
        public void ShouldUpdateEntityUserWhenDBContextIsValid()
        {
            CreateWorker();
            _spacePlanningUnitOfWork.EntityUserRepository.Add(worker);            
            User newUser = new User() { UserId = Guid.NewGuid(), Username = "roger@test.com", Password = "132456" };
            Entity currentEnttity = worker.Entity;
            _spacePlanningUnitOfWork.EntityUserRepository.Delete(worker);
            EntityUser newWorker = new EntityUser() { Entity = currentEnttity, User = newUser };
            _spacePlanningUnitOfWork.EntityUserRepository.Add(newWorker);
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual("roger@test.com", _spacePlanningUnitOfWork.EntityUserRepository.GetById(newWorker.EntityId,
                newWorker.UserId).User.Username);
            Assert.AreEqual("132456", _spacePlanningUnitOfWork.EntityUserRepository.GetById(newWorker.EntityId, 
                newWorker.UserId).User.Password);

        }

        [TestMethod]
        public void ShouldRemoveEntityUserWhenDBContextIsValid()
        {
            CreateWorker();
            _spacePlanningUnitOfWork.EntityUserRepository.Add(worker);
            _spacePlanningUnitOfWork.Save();
            Assert.IsNotNull(_spacePlanningUnitOfWork.EntityUserRepository.GetById(worker.EntityId, worker.UserId));
            _spacePlanningUnitOfWork.EntityUserRepository.Delete(worker);
            _spacePlanningUnitOfWork.Save();
            Assert.IsNull(_spacePlanningUnitOfWork.EntityUserRepository.GetById(worker.EntityId, worker.UserId));
        }

        [TestMethod]
        public void ShouldGetUserWhenDBContextIsValid()
        {
            CreateWorker();
            CreateWorker();
            _spacePlanningUnitOfWork.EntityUserRepository.Add(worker);
            _spacePlanningUnitOfWork.Save();
            Assert.IsNotNull(_spacePlanningUnitOfWork.EntityUserRepository.GetById(worker.EntityId, worker.UserId));
        }

        private void CreateWorker()
        {
            EntityType banks = new EntityType()
            {
                EntityTypeId = Guid.NewGuid(),
                Name = "Banks",
                Description = "Banks organizations"

            };
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            Entity bisa = new Entity()
            {
                EntityId = Guid.NewGuid(),
                Name = "BISA Bank",
                Description = "BISA Bank",
                EntityTypeId = banks.EntityTypeId

            };
            User juanWorker = new User() { Username = "juan@ist.com", Password ="1234", UserId = Guid.NewGuid() };
            worker = new EntityUser() { Entity = bisa, User = juanWorker };

        }
    }
}

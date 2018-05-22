using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryEntityTest : AbstractRepositoryTest
    {
        private Entity entity;
      
        [TestMethod]
        public void ShouldInsertEntityWhenDBContextIsValid()
        {
            CreateEntity();
            _spacePlanningUnitOfWork.EntityRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId) != null);
        }

        [TestMethod]
        public void ShouldDeleteEntityWhenDBContextIsValid()
        {
            CreateEntity();
            _spacePlanningUnitOfWork.EntityRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId) != null);
            _spacePlanningUnitOfWork.EntityRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId) == null);
        }

        [TestMethod]
        public void ShouldUpdateEntityWhenDBContextIsValid()
        {
            CreateEntity();
            string newBankName = "U.S. Bancorp";
            string newDescription = "U.S. Bancorp operates under the second-oldest continuous national charter";
            _spacePlanningUnitOfWork.EntityRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            this.entity = _spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId);
            this.entity.Name = newBankName;
            this.entity.Description = newDescription;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(newBankName, _spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId).Name);
            Assert.AreEqual(newDescription, 
                _spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId).Description);
        }

        [TestMethod]
        public void ShouldGetEntityWhenDBContextIsValid()
        {
            CreateEntity();
            _spacePlanningUnitOfWork.EntityRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            entity = _spacePlanningUnitOfWork.EntityRepository.GetById(entity.EntityId);
            Assert.IsNotNull(entity);
        }

        private void CreateEntity()
        {
            EntityType entityType = new EntityType()
            {
                EntityTypeId = Guid.NewGuid(),
                Name = "Banks",
                Description = "Banks organizations"

            };
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(entityType);
            _spacePlanningUnitOfWork.Save();
            entity = new Entity()
            {
                EntityId = Guid.NewGuid(),
                Name = "BISA Bank",
                Description = "BISA Bank",
                EntityTypeId = entityType.EntityTypeId

            };
        }
    }
}

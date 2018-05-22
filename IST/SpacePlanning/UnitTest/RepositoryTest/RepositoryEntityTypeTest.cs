using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryEntityTypeTest : AbstractRepositoryTest
    { 
        private EntityType banks;

        [TestMethod]
        public void ShouldInsertEntityTypeWhenDBContextIsValid()
        {
            CreateBank();
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityTypeRepository.GetById(banks.EntityTypeId) != null);
        }

        [TestMethod]
        public void ShouldDeleteEntityTypeWhenDBContextIsValid()
        {
            CreateBank();
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityTypeRepository.GetById(banks.EntityTypeId) != null);
            _spacePlanningUnitOfWork.EntityTypeRepository.Delete(banks);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.EntityTypeRepository.GetById(banks.EntityTypeId) == null);
        }

        [TestMethod]
        public void ShouldUpdateEntityTypeWhenDBContextIsValid()
        {
            CreateBank();
            string cooperative = "cooperative";
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            this.banks = _spacePlanningUnitOfWork.EntityTypeRepository.GetById(banks.EntityTypeId);
            this.banks.Name = cooperative;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(cooperative, _spacePlanningUnitOfWork.EntityTypeRepository.
                GetById(banks.EntityTypeId).Name);
        }

        [TestMethod]
        public void ShouldGetEntityTypeWhenDBContextIsValid()
        {
            CreateBank();
            _spacePlanningUnitOfWork.EntityTypeRepository.Add(banks);
            _spacePlanningUnitOfWork.Save();
            banks = _spacePlanningUnitOfWork.EntityTypeRepository.GetById(banks.EntityTypeId);
            Assert.IsNotNull(banks);
        }        

        private void CreateBank()
        {
            banks = new EntityType()
            {
                EntityTypeId = Guid.NewGuid(),
                Name = "Banks",
                Description = "Banks organizations"

            };
        }
    }
}

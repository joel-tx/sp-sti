using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryElementTypeTest : AbstractRepositoryTest
    {
        private ElementType chairs;
        
        [TestMethod]
        public void ShouldInsertElementTypeWhenDBContextIsValid()
        {
            CreateChairs();
            _spacePlanningUnitOfWork.ElementypeRepository.Add(chairs);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementypeRepository.GetById(chairs.ElementTypeId) != null);
        }

        [TestMethod]
        public void ShouldDeleteElementTypegWhenDBContextIsValid()
        {
            CreateChairs();
            _spacePlanningUnitOfWork.ElementypeRepository.Add(chairs);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementypeRepository.GetById(chairs.ElementTypeId) != null);
            _spacePlanningUnitOfWork.ElementypeRepository.Delete(chairs);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementypeRepository.GetById(chairs.ElementTypeId) == null);
        }

        [TestMethod]
        public void ShouldUpdateElementTypeWhenDBContextIsValid()
        {
            CreateChairs();
            string name = "tx chair v2";
            _spacePlanningUnitOfWork.ElementypeRepository.Add(this.chairs);
            _spacePlanningUnitOfWork.Save();
            this.chairs = _spacePlanningUnitOfWork.ElementypeRepository.GetById(this.chairs.ElementTypeId);
            this.chairs.Name = name;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(name, _spacePlanningUnitOfWork.ElementypeRepository.
                GetById(this.chairs.ElementTypeId).Name);
        }

        [TestMethod]
        public void ShouldGetElementTypeWhenDBContextIsValid()
        {
            CreateChairs();
            _spacePlanningUnitOfWork.ElementypeRepository.Add(chairs);
            _spacePlanningUnitOfWork.Save();
            chairs = _spacePlanningUnitOfWork.ElementypeRepository.GetById(chairs.ElementTypeId);
            Assert.IsNotNull(chairs);
        }

        private void CreateChairs()
        {
            chairs = new ElementType() { ElementTypeId = Guid.NewGuid(), Name = "chair",
                Description = "chair of computer, chair of kitchen, chair of cafetery" };
        }
    }
}

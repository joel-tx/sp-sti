using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryLayerTypeTest : AbstractRepositoryTest
    {      
        private LayerType electricityLayer;      

        [TestMethod]
        public void ShouldInsertLayerTypeWhenDBContextIsValid()
        {
            CreateLayerType();
            _spacePlanningUnitOfWork.LayerTypeRepository.Add(electricityLayer);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LayerTypeRepository.GetById(electricityLayer.LayerTypeId) != null);
        }

        [TestMethod]
        public void ShouldDeleteLayerTypeWhenDBContextIsValid()
        {
            CreateLayerType();
            _spacePlanningUnitOfWork.LayerTypeRepository.Add(electricityLayer);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LayerTypeRepository.GetById(electricityLayer.LayerTypeId) != null);
            _spacePlanningUnitOfWork.LayerTypeRepository.Delete(electricityLayer);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LayerTypeRepository.GetById(electricityLayer.LayerTypeId) == null);
        }

        [TestMethod]
        public void ShouldUpdateLayerTypeWhenDBContextIsValid()
        {
            CreateLayerType();
            string electricalCable = "electrical cable,";
            _spacePlanningUnitOfWork.LayerTypeRepository.Add(electricityLayer);
            _spacePlanningUnitOfWork.Save();
            this.electricityLayer = _spacePlanningUnitOfWork.LayerTypeRepository.GetById(electricityLayer.LayerTypeId);
            this.electricityLayer.Name = electricalCable;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(electricalCable, _spacePlanningUnitOfWork.LayerTypeRepository.
                GetById(electricityLayer.LayerTypeId).Name);
        }

        [TestMethod]
        public void ShouldGetLayerTypeWhenDBContextIsValid()
        {
            CreateLayerType();
            _spacePlanningUnitOfWork.LayerTypeRepository.Add(electricityLayer);
            _spacePlanningUnitOfWork.Save();
            electricityLayer = _spacePlanningUnitOfWork.LayerTypeRepository.GetById(electricityLayer.LayerTypeId);
            Assert.IsNotNull(electricityLayer);
        }       

        private LayerType CreateLayerType()
        {
            electricityLayer = new LayerType()
            {
                LayerTypeId = Guid.NewGuid(),
                Name = "electricity layer",
                Description = "electrical grid"
            };

            return electricityLayer;
        }
    }
}

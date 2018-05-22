using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryGraphicTypeTest : AbstractRepositoryTest
    {  
        private GraphicType furniture;       

        [TestMethod]
        public void ShouldInsertGraphicTypeWhenDBContextIsValid()
        {
            furniture = CreateGraphicType();
            _spacePlanningUnitOfWork.GraphicTypeRepository.Add(furniture);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId) != null);
        }

        [TestMethod]
        public void ShouldDeleteGraphicTypeWhenDBContextIsValid()
        {
            furniture = CreateGraphicType();
            _spacePlanningUnitOfWork.GraphicTypeRepository.Add(furniture);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId) != null);
            _spacePlanningUnitOfWork.GraphicTypeRepository.Delete(furniture);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId) == null);
        }

        [TestMethod]
        public void ShouldUpdateGraphicTypeWhenDBContextIsValid()
        {
            furniture = CreateGraphicType();
            string graphicName = "New GraphicName";
            _spacePlanningUnitOfWork.GraphicTypeRepository.Add(furniture);
            _spacePlanningUnitOfWork.Save();
            this.furniture = _spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId);
            this.furniture.Name = graphicName;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(graphicName, _spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId).Name);
        }

        [TestMethod]
        public void ShouldGetGraphicTypeWhenDBContextIsValid()
        {
            furniture = CreateGraphicType();
            _spacePlanningUnitOfWork.GraphicTypeRepository.Add(furniture);
            _spacePlanningUnitOfWork.Save();
            furniture = _spacePlanningUnitOfWork.GraphicTypeRepository.GetById(furniture.GraphicTypeId);
            Assert.IsNotNull(furniture);
        }      

        private GraphicType CreateGraphicType()
        {
            furniture = new GraphicType()
            {
                GraphicTypeId = Guid.NewGuid(),
                Name = "furniture",
                Description = "Group of furniture"
            };

            return furniture;
        }
    }
}

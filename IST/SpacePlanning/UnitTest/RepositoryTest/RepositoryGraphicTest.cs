using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryGraphicTest : AbstractRepositoryTest
    {
        private Graphic desktop;

        [TestMethod]
        public void ShoudInsertGraphicWhenDBContextIsValid()
        {
            CreateDesktop();
            _spacePlanningUnitOfWork.GraphicRepository.Add(desktop);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId) != null);
        }

        [TestMethod]
        public void ShouldDeleteGraphicWhenDBContextIsValid()
        {
            CreateDesktop();
            _spacePlanningUnitOfWork.GraphicRepository.Add(desktop);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId) != null);
            _spacePlanningUnitOfWork.GraphicRepository.Delete(desktop);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId) == null);
        }

        [TestMethod]
        public void ShouldUpdateGraphicWhenDBContextIsValid()
        {
            CreateDesktop();
            string graphicName = "computer stand";
            _spacePlanningUnitOfWork.GraphicRepository.Add(desktop);
            _spacePlanningUnitOfWork.Save();
            this.desktop = _spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId);
            this.desktop.Name = graphicName;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(graphicName, _spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId).Name);
        }

        [TestMethod]
        public void ShouldGetGraphicWhenDBContextIsValid()
        {
            CreateDesktop();
            _spacePlanningUnitOfWork.GraphicRepository.Add(desktop);
            _spacePlanningUnitOfWork.Save();
            desktop = _spacePlanningUnitOfWork.GraphicRepository.GetById(desktop.GraphicId);
            Assert.IsNotNull(desktop);
        }

        private void CreateDesktop()
        {
            GraphicType graphicType = new GraphicType()
            {
                GraphicTypeId = Guid.NewGuid(),
                Name = "Straight",
                Description = "Straight"
            };
            desktop = new Graphic()
            {
                GraphicId = Guid.NewGuid(),
                Height = 100,
                Width = 200,
                GraphicTypeId = graphicType.GraphicTypeId,
                Name = "Straight",
                Description = "Group of Straight"
            };
            desktop.GraphicType = graphicType;

        }
    }
}

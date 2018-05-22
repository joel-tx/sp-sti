using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryElementTest : AbstractRepositoryTest
    {  
        private Element chairElement;        

        [TestMethod]
        public void ShouldInsertElementWhenDBContextIsValid()
        {
            CreateElement();
            _spacePlanningUnitOfWork.ElementRepository.Add(chairElement);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementRepository.GetById(chairElement.ElementId) != null);
        }

        [TestMethod]
        public void ShouldDeleteElementWhenDBContextIsValid()
        {
            CreateElement();
            _spacePlanningUnitOfWork.ElementRepository.Add(chairElement);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementRepository.GetById(chairElement.ElementId) != null);
            _spacePlanningUnitOfWork.ElementRepository.Delete(chairElement);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementRepository.GetById(chairElement.ElementId) == null);
        }

        [TestMethod]
        public void ShouldUpdateElementWhenDBContextIsValid()
        {
            CreateElement();
            string label = "tx chair v2";
            _spacePlanningUnitOfWork.ElementRepository.Add(this.chairElement);
            _spacePlanningUnitOfWork.Save();
            this.chairElement = _spacePlanningUnitOfWork.ElementRepository.GetById(this.chairElement.ElementId);
            this.chairElement.Label = label;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(label, _spacePlanningUnitOfWork.ElementRepository.
                GetById(this.chairElement.ElementId).Label);
        }

        [TestMethod]
        public void ShouldGetElementWhenDBContextIsValid()
        {
            CreateElement();
            _spacePlanningUnitOfWork.ElementRepository.Add(chairElement);
            _spacePlanningUnitOfWork.Save();
            chairElement = _spacePlanningUnitOfWork.ElementRepository.GetById(chairElement.ElementId);
            Assert.IsNotNull(chairElement);
        }

        public void CreateElement()
        {
            GraphicType graphicType = new GraphicType() { GraphicTypeId = Guid.NewGuid(),
                Name = "Straight", Description = "Straight" };
            Graphic graphic = new Graphic()
            {
                GraphicId = Guid.NewGuid(),
                Height = 100,
                Width = 200,
                GraphicTypeId = graphicType.GraphicTypeId,
                Name = "Straight",
                Description = "Group of Straight"
            };
            graphic.GraphicType = graphicType;
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.GraphicRepository.Add(graphic);
            _spacePlanningUnitOfWork.Save();
            ElementType chairs = new ElementType { ElementTypeId = Guid.NewGuid(),
                Name = "chairs", Description = "chairs" };
            chairElement = new Element()
            {
                ElementId = Guid.NewGuid(),
                GraphicId = graphic.GraphicId,
                ElementTypeId = chairs.ElementTypeId,
                Description = "computer Chair",
                Label = "tx chair"
            };
            chairElement.ElementType = chairs;
        }
    }
}

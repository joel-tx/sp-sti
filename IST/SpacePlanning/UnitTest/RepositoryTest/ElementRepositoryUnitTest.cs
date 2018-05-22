using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class ElementRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenElementRepositoryIsValid()
        {
            var entity = FactoryElement.RandomCreate();
            _spacePlanningUnitOfWork.ElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ElementRepository.GetById(entity.ElementId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenElementRepositoryIsValid()
        {
            var entity = FactoryElement.RandomCreate();
            _spacePlanningUnitOfWork.ElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.ElementRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.ElementRepository.GetById(entity.ElementId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenElementRepositoryIsValid()
        {
            var entity = FactoryElement.RandomCreate();
            _spacePlanningUnitOfWork.ElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.ElementRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ElementRepository.GetById(entity.ElementId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
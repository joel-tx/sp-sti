using Microsoft.VisualStudio.TestTools.UnitTesting;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class ObjectRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenObjectRepositoryIsValid()
        {
            Object entity = FactoryObject.RandomCreate();
            _spacePlanningUnitOfWork.ObjectRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ObjectRepository.GetById(entity.ObjectId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenObjectRepositoryIsValid()
        {
            Object entity = FactoryObject.RandomCreate();
            _spacePlanningUnitOfWork.ObjectRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.ObjectRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.ObjectRepository.GetById(entity.ObjectId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenObjectRepositoryIsValid()
        {
            Object entity = FactoryObject.RandomCreate();
            _spacePlanningUnitOfWork.ObjectRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.ObjectRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ObjectRepository.GetById(entity.ObjectId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class OperationRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenOperationRepositoryIsValid()
        {
            var entity = FactoryOperation.RandomCreate();
            _spacePlanningUnitOfWork.OperationRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.OperationRepository.GetById(entity.OperationId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenOperationRepositoryIsValid()
        {
            var entity = FactoryOperation.RandomCreate();
            _spacePlanningUnitOfWork.OperationRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.OperationRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.OperationRepository.GetById(entity.OperationId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenOperationRepositoryIsValid()
        {
            var entity = FactoryOperation.RandomCreate();
            _spacePlanningUnitOfWork.OperationRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.OperationRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.OperationRepository.GetById(entity.OperationId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

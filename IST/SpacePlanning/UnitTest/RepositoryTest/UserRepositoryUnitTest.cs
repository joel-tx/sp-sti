using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class UserRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenUserRepositoryIsValid()
        {
            var entity = FactoryUser.RandomCreate();
            _spacePlanningUnitOfWork.UserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.UserRepository.GetById(entity.UserId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenUserRepositoryIsValid()
        {
            var entity = FactoryUser.RandomCreate();
            _spacePlanningUnitOfWork.UserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.UserRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.UserRepository.GetById(entity.UserId);
            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenUserRepositoryIsValid()
        {
            var entity = FactoryUser.RandomCreate();
            _spacePlanningUnitOfWork.UserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.UserRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.UserRepository.GetById(entity.UserId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

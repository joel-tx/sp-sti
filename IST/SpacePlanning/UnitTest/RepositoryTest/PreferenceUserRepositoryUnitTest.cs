using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PreferenceUserRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPreferenceUserRepositoryIsValid()
        {
            var entity = FactoryPreferenceUser.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PreferenceUserRepository.GetById(entity.UserId, entity.PreferenceId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPreferenceUserRepositoryIsValid()
        {
            var entity = FactoryPreferenceUser.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.PreferenceUserRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PreferenceUserRepository.GetById(entity.UserId, entity.PreferenceId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenPreferenceUserRepositoryIsValid()
        {
            var entity = FactoryPreferenceUser.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PreferenceUserRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PreferenceUserRepository.GetById(entity.PreferenceId, entity.UserId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

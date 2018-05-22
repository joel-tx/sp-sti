using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PreferenceRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPreferenceRepositoryIsValid()
        {
            var entity = FactoryPreference.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PreferenceRepository.GetById(entity.PreferenceId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPreferenceRepositoryIsValid()
        {
            var entity = FactoryPreference.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PreferenceRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PreferenceRepository.GetById(entity.PreferenceId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenPreferenceRepositoryIsValid()
        {
            var entity = FactoryPreference.RandomCreate();
            _spacePlanningUnitOfWork.PreferenceRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PreferenceRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PreferenceRepository.GetById(entity.PreferenceId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

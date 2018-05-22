using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PlanUserRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPlanUSerRepositoryIsValid()
        {
            var entity = FactoryPlanUser.RandomCreate();
            _spacePlanningUnitOfWork.PlanUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PlanUserRepository.GetById(entity.PlanId, entity.UserId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPlanUserRepositoryIsValid()
        {
            var entity = FactoryPlanUser.RandomCreate();
            _spacePlanningUnitOfWork.PlanUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.PlanUserRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PlanUserRepository.GetById(entity.PlanId, entity.UserId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenPlanUserRepositoryIsValid()
        {
            var entity = FactoryPlanUser.RandomCreate();
            _spacePlanningUnitOfWork.PlanUserRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PlanUserRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PlanUserRepository.GetById(entity.PlanId, entity.UserId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
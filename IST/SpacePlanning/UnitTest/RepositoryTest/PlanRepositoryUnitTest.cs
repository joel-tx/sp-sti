using Microsoft.VisualStudio.TestTools.UnitTesting;
using IST.SpacePlanning.Data.EntityModel;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PlanRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPlanRepositoryIsValid()
        {
            Plan entity = FactoryPlan.RandomCreate();
            _spacePlanningUnitOfWork.PlanRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PlanRepository.GetById(entity.PlanId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPlanRepositoryIsValid()
        {
            var entity = FactoryPlan.RandomCreate();
            _spacePlanningUnitOfWork.PlanRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.PlanRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PlanRepository.GetById(entity.PlanId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenPlanRepositoryIsValid()
        {
            var entity = FactoryPlan.RandomCreate();
            _spacePlanningUnitOfWork.PlanRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PlanRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PlanRepository.GetById(entity.PlanId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class SceneTypeRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenSceneTypeRepositoryIsValid()
        {
            var entity = FactorySceneType.RandomCreate();
            _spacePlanningUnitOfWork.SceneTypeRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.SceneTypeRepository.GetById(entity.SceneTypeId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenSceneTypeRepositoryIsValid()
        {
            var entity = FactorySceneType.RandomCreate();
            _spacePlanningUnitOfWork.SceneTypeRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.SceneTypeRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.SceneTypeRepository.GetById(entity.SceneTypeId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenSceneTypeRepositoryIsValid()
        {
            var entity = FactorySceneType.RandomCreate();
            _spacePlanningUnitOfWork.SceneTypeRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.SceneTypeRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.SceneTypeRepository.GetById(entity.SceneTypeId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

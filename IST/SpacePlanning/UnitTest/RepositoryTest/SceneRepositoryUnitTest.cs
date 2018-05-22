using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class SceneRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenSceneRepositoryIsValid()
        {
            var entity = FactoryScene.RandomCreate();
            _spacePlanningUnitOfWork.SceneRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.SceneRepository.GetById(entity.SceneId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenSceneRepositoryIsValid()
        {
            var entity = FactoryScene.RandomCreate();
            _spacePlanningUnitOfWork.SceneRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.SceneRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.SceneRepository.GetById(entity.SceneId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenSceneRepositoryIsValid()
        {
            var entity = FactoryScene.RandomCreate();
            _spacePlanningUnitOfWork.SceneRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.SceneRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.SceneRepository.GetById(entity.SceneTypeId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
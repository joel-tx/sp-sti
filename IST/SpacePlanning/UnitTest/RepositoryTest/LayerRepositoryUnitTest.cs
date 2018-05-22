using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class LayerRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenLayerRepositoryIsValid()
        {
            var entity = FactoryLayer.RandomCreate();
            _spacePlanningUnitOfWork.LayerRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.LayerRepository.GetById(entity.LayerId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenLayerRepositoryIsValid()
        {
            var entity = FactoryLayer.RandomCreate();
            _spacePlanningUnitOfWork.LayerRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.LayerRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.LayerRepository.GetById(entity.LayerId);

            Assert.IsTrue(entity.Equals(retrived));
        }
        [TestMethod]
        public void ShouldDeleteWhenLayerRepositoryIsValid()
        {
            var entity = FactoryLayer.RandomCreate();
            _spacePlanningUnitOfWork.LayerRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.LayerRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.LayerRepository.GetById(entity.LayerId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
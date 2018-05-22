using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.UnitTest.RepositoryTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest
{
    [TestClass]
    public class NameRepositoryUnitTest: AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenNameRepositoryIsValid()
        {
            Name entity = FactoryName.RandomCreate();
            _spacePlanningUnitOfWork.NameRepository.Add(entity);

            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.NameRepository.GetById(entity.NameId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenNameRepositoryIsValid()
        {
            Name entity = FactoryName.RandomCreate();
            _spacePlanningUnitOfWork.NameRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.NameRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.NameRepository.GetById(entity.NameId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenNameRepositoryIsValid()
        {
            Name entity = FactoryName.RandomCreate();
            _spacePlanningUnitOfWork.NameRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.NameRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.NameRepository.GetById(entity.NameId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}

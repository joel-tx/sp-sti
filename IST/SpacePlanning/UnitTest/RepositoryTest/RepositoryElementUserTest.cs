using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryElementUserTest : AbstractRepositoryTest
    {
        private ElementUser ownerUser;


        [TestMethod]
        public void ShouldInsertElementUserWhenDBContextIsValid()
        {
            CreateElementUser();
            _spacePlanningUnitOfWork.ElemenUserRepository.Add(ownerUser);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElementRepository.GetById(ownerUser.ElementId) != null);
            Assert.IsTrue(_spacePlanningUnitOfWork.UserRepository.GetById(ownerUser.UserId) != null);
            Assert.IsTrue(_spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId, 
                ownerUser.UserId) != null);
        }

        [TestMethod]
        public void ShouldDeleteElementUserWhenDBContextIsValid()
        {
            CreateElementUser();
            _spacePlanningUnitOfWork.ElemenUserRepository.Add(ownerUser);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId,
                ownerUser.UserId) != null);
            _spacePlanningUnitOfWork.ElemenUserRepository.Delete(ownerUser);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId, 
                ownerUser.UserId) == null);
        }

        [TestMethod]
        public void ShouldUpdateElementUserWhenDBContextIsValid()
        {
            CreateElementUser();
            User newUser = new User() { UserId = Guid.NewGuid(), Username = "dev1@gmail.com", Password = "123" };
            _spacePlanningUnitOfWork.UserRepository.Add(newUser);           
            _spacePlanningUnitOfWork.ElemenUserRepository.Add(ownerUser);           
            ownerUser = _spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId, ownerUser.UserId);
            ownerUser.User = null;
            ownerUser.UserId = newUser.UserId;
            ownerUser.User = newUser;
            _spacePlanningUnitOfWork.ElemenUserRepository.Update(ownerUser);
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual("dev1@gmail.com", _spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId,
                ownerUser.UserId).User.Username);
        }

        [TestMethod]
        public void ShouldGetElementUserWhenDBContextIsValid()
        {
            CreateElementUser();
            _spacePlanningUnitOfWork.ElemenUserRepository.Add(ownerUser);
            _spacePlanningUnitOfWork.Save();
            ownerUser = _spacePlanningUnitOfWork.ElemenUserRepository.GetById(ownerUser.ElementId, ownerUser.UserId);
            Assert.IsNotNull(ownerUser);
        }

        private void CreateElementUser()
        {
            Element chairElement;
            GraphicType graphicType = new GraphicType() { GraphicTypeId = Guid.NewGuid(),
                Name = "Straight", Description = "Straight" };
            Graphic graphic = new Graphic()
            {
                GraphicId = Guid.NewGuid(),
                Height = 100,
                Width = 200,
                GraphicTypeId = graphicType.GraphicTypeId,
                Name = "Straight",
                Description = "Group of Straight"
            };
            graphic.GraphicType = graphicType;
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.GraphicRepository.Add(graphic);
            _spacePlanningUnitOfWork.Save();
            ElementType chairs = new ElementType { ElementTypeId = Guid.NewGuid(),
                Name = "chairs", Description = "chairs" };
            chairElement = new Element()
            {
                ElementId = Guid.NewGuid(),
                GraphicId = graphic.GraphicId,
                ElementTypeId = chairs.ElementTypeId,
                Description = "computer Chair",
                Label = "tx chair"
            };
            chairElement.ElementType = chairs;
            _spacePlanningUnitOfWork.ElementypeRepository.Add(chairs);
            _spacePlanningUnitOfWork.Save();
            User user = new User() { Username = "user1 dev", Password = "test123",
                UserId = Guid.NewGuid() };
            _spacePlanningUnitOfWork.UserRepository.Add(user);
            _spacePlanningUnitOfWork.Save();
            ownerUser = new ElementUser() { ElementId = chairElement.ElementId, UserId = user.UserId,
                Element = chairElement, User = user };
        }
    }
}

using System;
using Xunit;
using Backend.Models;
using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;

namespace Backend.UnitTests
{
    public class Tests
    {
        ContactController GetInstance(IContactRepository repo){
            return new ContactController(repo);
        }

        Contact createDummyContact(){
            return new Contact(){
                FirstName = "Q"
            };
        }

        [Fact]
        public void GetById_FailsWithInvalidContact() 
        {
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.GetById(string.Empty);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_SucceedsWithValidContact() 
        {
            var repo = new Mock<IContactRepository>();
            var contact = createDummyContact();
            repo.Setup(r => r.Find(It.IsAny<string>())).Returns(contact);
            var controller = GetInstance(repo.Object);
            var result = controller.GetById(string.Empty);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void Create_FailsWithNullInput(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Create(null);
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public void Create_FailsWithValidInput(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Create(createDummyContact());
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void Delete_FailsWithInvalidContact(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Delete(string.Empty);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_SucceedsWithValidContact() 
        {
            var repo = new Mock<IContactRepository>();
            var contact = createDummyContact();
            repo.Setup(r => r.Find(It.IsAny<string>())).Returns(contact);
            var controller = GetInstance(repo.Object);
            var result = controller.Delete(string.Empty);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_FailsWithNoContact(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Update(null, null);
            Assert.IsType<BadRequestResult>(result);
        }
        
        [Fact]
        public void Update_FailsWithInconsistentContact(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Update("10", new Contact{ Id = "11" });
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Update_FailsWithInvalidContact(){
            var repo = new Mock<IContactRepository>();
            var controller = GetInstance(repo.Object);
            var result = controller.Update("10", new Contact{ Id = "10" });
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Update_SucceedsWithValidContact() 
        {
            var repo = new Mock<IContactRepository>();
            var contact = createDummyContact();
            repo.Setup(r => r.Find(It.IsAny<string>())).Returns(contact);
            var controller = GetInstance(repo.Object);
            var result = controller.Update(contact.Id, contact);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
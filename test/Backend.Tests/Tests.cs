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
                Name = "Q"
            };
        }

        [Fact]
        public void GetAll_HasItems() 
        {
            var repo = new Mock<IContactRepository>();
            var contact = createDummyContact();
            repo.Setup(r => r.GetAll()).Returns(new Contact[] { contact });
            var controller = GetInstance(repo.Object);
            var result = controller.GetAll();
            Assert.Equal(result.First().Name, contact.Name);
        }
    }
}
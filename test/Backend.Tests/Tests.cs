using System;
using Xunit;
using Backend.Models;
using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Backend.UnitTests
{
    public class Tests
    {
        ContactController GetInstance(){
            return new ContactController(new ContactRepository());
        }

        [Fact]
        public void GetAll_HasItems() 
        {
            var controller = GetInstance();
            controller.Create(new Contact(){
                Name = "Q"
            });
            var result = controller.GetAll();
            Assert.Equal(result.First().Name, "Q");
        }
    }
}
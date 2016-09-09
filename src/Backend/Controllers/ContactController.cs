using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public IContactRepository Contacts { get; set; }

        public ContactController(IContactRepository contacts)
        {
            Contacts = contacts;
        }
    }
}
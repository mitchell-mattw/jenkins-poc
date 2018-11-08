using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailerService.Helpers;
using EmailerService.Models;
using EmailerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Notify;
using Notify.Client;
using Notify.Models.Responses;

namespace EmailerService.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailerController : Controller
    {
        private readonly IEmailNotifyService _emailNotifyService;

        
        public EmailerController(IEmailNotifyService emailNotifyService)
        {
            _emailNotifyService = emailNotifyService;

        }

       
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ASP NET CORE", "WEB API" };
        }

        [HttpPost]
        public IActionResult Post([FromBody] TemplateOptions options)
        {
            if (options == null)
            {
                // return BadRequest();
                return BadRequest();
            }

            EmailNotificationResponse response;
            
            try
            {
                response = _emailNotifyService.SendEmail(options);
                // Log response????
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            //TODO
            //return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
            return Ok(response.id);
        }


    }
}
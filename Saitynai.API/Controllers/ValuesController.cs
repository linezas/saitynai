using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Saitynai.API.Data;
using Saitynai.API.Models;
using System.Web.Http;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Saitynai.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;
        public ValuesController(DataContext context)
        {
            this.context = context;

        }
        // GET api/values
        [HttpGet]
        public IActionResult getValues()
        {
            var values = context.Users.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult getValue(int id)
        {
            
            var value = context.Users.FirstOrDefault(x => x.id==id);
            if(value==null)
            {
                return NotFound("id doesnt exist");
            }
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public IActionResult postValue(AppUser user)
        {
            if(user==null){
                return BadRequest("bad object format was given");
            }
            if(context.Users.FirstOrDefault(x => x.id==user.id)!=null)
            {
              //var value = context.Users.FirstOrDefault(x => x.id==user.id);
              //return new NegotiatedContentResult<T>(HttpStatusCode.Conflict, value, this);
                 Response.StatusCode = StatusCodes.Status409Conflict;
                // return BadRequest("duplicate");
                 return Conflict("duplicate found");
                 //return new EmptyResult();
                
            }
            context.Users.Add(user);
            context.SaveChanges();
            return Created("Created",user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
         public IActionResult putValue(int id, AppUser user)
        {
            var value = context.Users.FirstOrDefault(x => x.id==id);
            if(value==null)
            {
                return NotFound("id doesnt exist");
            }
            if(user.id!=id)
            {
                return BadRequest("ids dont match");
            }
            value.name=user.name;
            context.SaveChanges();
            return Ok(value);
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult deleteValue(int id)
        {
            var value = context.Users.FirstOrDefault(x => x.id==id);
            if(value==null)
            {
                return NotFound("it was not found");
            }
            context.Users.Remove(value);
            context.SaveChanges();
            return Ok(value);
        }
    }
}

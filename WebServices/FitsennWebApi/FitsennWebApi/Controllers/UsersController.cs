using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FitsennWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitsennWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController> Вход
        [HttpGet("{emailOrPhone}/{passWordHash}")]
        public async Task<Person> GetUser(string emailOrPhone, string passWordHash)
        {
            await using var dbContext = new FitsennContext();
            return await dbContext.People.FirstOrDefaultAsync(_ => _.Email.Equals(emailOrPhone) && _.Password.Equals(passWordHash));
        }

        // POST api/<UsersController> Изменение данных
        [HttpPost]
        public async Task Post([FromBody] Person person)
        {
            await using var dbContext = new FitsennContext();
            if (await dbContext.People.AnyAsync(_ => _.Email.Equals(person.Email) || _.Id.Equals(person.Id)))
                BadRequest();
            dbContext.People.Update(person);
            await dbContext.SaveChangesAsync();
        }

        // PUT api/<UsersController> Регистрация
        [HttpPut]
        public async Task Put([FromBody] Person person)
        {
            using (var dbContext = new FitsennContext())
            {
                try
                {
                    person.Id = Guid.NewGuid();
                    if (await dbContext.People.AnyAsync(_ => _.Email.Equals(person.Email) || _.Id.Equals(person.Id)))
                        BadRequest();
                    dbContext.People.Add(person);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    var s = e.Message;
                }
            }
        }
    }
}

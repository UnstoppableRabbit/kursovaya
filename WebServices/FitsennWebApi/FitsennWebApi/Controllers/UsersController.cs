using System;
using System.Security.Cryptography;
using System.Text;
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
        [HttpGet("{emailOrPhone}/{passWord}")]
        public async Task<Person> GetUser(string emailOrPhone, string passWord)
        {
            await using var dbContext = new FitsennContext();
            return await dbContext.People.FirstOrDefaultAsync(_ => _.Email.Equals(emailOrPhone) && _.Password.Equals(GetHash(passWord)));
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
            await using var dbContext = new FitsennContext();
            try
            {
                person.Id = Guid.NewGuid();
                if (await dbContext.People.AnyAsync(_ => _.Email.Equals(person.Email) || _.Id.Equals(person.Id)))
                    BadRequest();
                person.Password = GetHash(person.Password);
                dbContext.People.Add(person);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }

        private string GetHash(string input)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitsennWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FitsennWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        // GET: api/<StatisticController>/diet/persId
        [HttpGet("diet/{id}")]
        public async Task<List<Diet>> Get(Guid id)
        {
            await using var dbContext = new FitsennContext();
            return await dbContext.Diets.Where(_ => _.PersonId.Equals(id)).OrderBy(_ => _.Date).Take(7)
                .ToListAsync();
        }

        // GET api/<StatisticController>/log/persId
        [HttpGet("log/{id}")]
        public async Task<List<PersonSportLog>> GetLogs(Guid id)
        {
            await using var dbContext = new FitsennContext();
            return await dbContext.PersonSportLogs.Where(_ => _.PersonId.Equals(id)).OrderBy(_ => _.Date).Take(7)
                .ToListAsync();
        }

        // POST api/<StatisticController>
        [HttpPost]
        public async Task Post([FromBody] PersonSportLog log)
        {
            await using var dbContext = new FitsennContext();
            if (await dbContext.PersonSportLogs.FirstOrDefaultAsync(_ => _.Id.Equals(log.Id)) != null)
                BadRequest();
            PersonSportLog nlog;
            if (await dbContext.PersonSportLogs.FirstOrDefaultAsync(_ => _.Date.Date.Equals(log.Date.Date) && _.PersonId.Equals(log.PersonId)) != null)
            {
                nlog = await dbContext.PersonSportLogs.FirstAsync(_ =>
                    _.Date.Date.Equals(log.Date.Date) && _.PersonId.Equals(log.PersonId));
                nlog.Weight = log.Weight;
                dbContext.PersonSportLogs.Update(nlog);
            }
            else
            {
                dbContext.PersonSportLogs.Add(log);
            }

            await dbContext.SaveChangesAsync();
        }

        // PUT api/<StatisticController>
        [HttpPut]
        public async Task Put([FromBody] Diet diet)
        {
            await using var dbContext = new FitsennContext();
            if (await dbContext.Diets.FirstOrDefaultAsync(_ => _.Id.Equals(diet.Id)) != null)
                BadRequest();
            Diet ndiet;
            if (await dbContext.Diets.FirstOrDefaultAsync(_ => _.Date.Date.Equals(diet.Date.Date) && _.PersonId.Equals(diet.PersonId)) != null)
            {
                ndiet = await dbContext.Diets.FirstAsync(_ =>
                    _.Date.Date.Equals(diet.Date.Date) && _.PersonId.Equals(diet.PersonId));
                ndiet.TotalCalories = diet.TotalCalories;
                dbContext.Diets.Update(ndiet);
            }
            else
            {
                dbContext.Diets.Add(diet);
            }

            await dbContext.SaveChangesAsync();
        }

        // DELETE api/<StatisticController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Bisycles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BicycleController : Controller
    {
        private readonly BicycleContext context;

        public BicycleController(BicycleContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Bicycle>>> Get()
        {
            return await context.Bicycle.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> Get(int id)
        {
            Bicycle bicycle = await context.Bicycle.FirstOrDefaultAsync(x => x.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return Ok(bicycle);
        }

        [HttpPost]
        public async Task<ActionResult<Bicycle>> Post(Bicycle bicycle)
        {
            context.Bicycle.Add(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpPut]
        public async Task<ActionResult<Bicycle>> Put(Bicycle bicycle)
        {
            context.Update(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> Delete(int id)
        {
            Bicycle bicycle = await context.Bicycle.FirstOrDefaultAsync(x => x.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }
            context.Bicycle.Remove(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisplaySweet;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace DisplaySweetWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly DisplaySweetDbContext _context;

        public ComponentsController(DisplaySweetDbContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        public IEnumerable<Component> GetComponents()
        {
            return _context.Components;
        }

        // GET: api/Components/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var component = await _context.Components.FindAsync(id);

            if (component == null)
            {
                return NotFound();
            }

            return Ok(component);
        }

        // PUT: api/Components/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponent([FromRoute] Guid id, [FromBody] Component component)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != component.Id)
            {
                return BadRequest();
            }

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Components
        [HttpPost]
        public async Task<ActionResult> PostComponent([FromBody] Component value)
        {
            _context.Components.Add(value);
            await _context.SaveChangesAsync();
            return Ok(value);
        }       

        private bool ComponentExists(Guid id)
        {
            return _context.Components.Any(e => e.Id == id);
        }
    }
}
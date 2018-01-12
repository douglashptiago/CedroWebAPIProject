using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Context;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Prato")]
    public class PratoController : Controller
    {
        private readonly MyContext _context;

        public PratoController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Prato> GetAll()
        {
            var result = _context.Prato
            .ToList();

            return result;
        }

        [HttpGet("{id}", Name = "GetPratos")]
        public IActionResult GetById(int id)
        {
            var item = _context.Prato.FirstOrDefault(t => t.PratoId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Prato prato)
        {
            if (prato == null)
            {
                return BadRequest();
            }

            _context.Prato.Add(prato);
            _context.SaveChanges();

            return CreatedAtRoute("GetPratos", new { id = prato.PratoId }, prato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Prato prato)
        {
            if (prato == null || prato.PratoId != id)
            {
                return BadRequest();
            }

            var todo = _context.Prato.FirstOrDefault(t => t.PratoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.NomePrato = prato.NomePrato;
            todo.Preco = prato.Preco;
            todo.RestauranteId = prato.RestauranteId;

            _context.Prato.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Prato.FirstOrDefault(t => t.PratoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Prato.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}

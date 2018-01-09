using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.Context;
using SampleWebAPI.Data.Models;

namespace SampleWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Prato")]
    public class PratoController : Controller
    {
        private readonly Context _context;

        public PratoController(Context context)
        {
            _context = context;

            //if (_context.Restaurantes.Count() == 0)
            //{
            //    _context.Restaurantes.Add(new Restaurante {  NomeRestaurante = "Teste1" });
            //    _context.SaveChanges();
            //}
        }

        [HttpGet]
        public IEnumerable<Prato> GetAll()
        {
            return _context.Pratos.ToList();
        }

        [HttpGet("{id}", Name = "GetPratos")]
        public IActionResult GetById(int id)
        {
            var item = _context.Pratos.FirstOrDefault(t => t.PratoId == id);
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

            _context.Pratos.Add(prato);
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

            var todo = _context.Pratos.FirstOrDefault(t => t.PratoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.NomePrato = prato.NomePrato;
            todo.Preco = todo.Preco;
            todo.RestauranteId = prato.RestauranteId;

            _context.Pratos.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Pratos.FirstOrDefault(t => t.PratoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Pratos.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
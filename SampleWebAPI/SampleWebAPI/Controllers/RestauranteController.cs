﻿using System;
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
    [Route("api/Restaurante")]
    public class RestauranteController : Controller
    {
        private readonly Context _context;

        public RestauranteController(Context context)
        {
            _context = context;

            //if (_context.Restaurantes.Count() == 0)
            //{
            //    _context.Restaurantes.Add(new Restaurante {  NomeRestaurante = "Teste1" });
            //    _context.SaveChanges();
            //}
        }

        [HttpGet]
        public IEnumerable<Restaurante> GetAll()
        {
            return _context.Restaurantes.ToList();
        }

        [HttpGet("{id}", Name = "GetRestaurantes")]
        public IActionResult GetById(int id)
        {
            var item = _context.Restaurantes.FirstOrDefault(t => t.RestauranteId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Restaurante restaurante)
        {
            if (restaurante == null)
            {
                return BadRequest();
            }

            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();

            return CreatedAtRoute("GetRestaurantes", new { id = restaurante.RestauranteId }, restaurante);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Restaurante restaurante)
        {
            if (restaurante == null || restaurante.RestauranteId != id)
            {
                return BadRequest();
            }

            var todo = _context.Restaurantes.FirstOrDefault(t => t.RestauranteId == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.NomeRestaurante = restaurante.NomeRestaurante;
            todo.Pratos = restaurante.Pratos;

            _context.Restaurantes.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Restaurantes.FirstOrDefault(t => t.RestauranteId == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWebAPI.Data.Models
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        public string NomeRestaurante { get; set; }

        public List<Prato> Pratos { get; set; }
    }
}

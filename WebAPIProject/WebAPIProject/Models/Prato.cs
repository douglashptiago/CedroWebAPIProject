using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string NomePrato { get; set; }
        public decimal Preco { get; set; }

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}

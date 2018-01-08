using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWebAPI.Data.Models
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string NomePrato { get; set; }

        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}

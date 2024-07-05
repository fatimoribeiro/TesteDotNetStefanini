using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atletas.DTO
{
    public class Atleta
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string apelido { get; set; }

        public DateTime nascimento { get; set; }

        public double altura { get; set; }

        public double peso { get; set; }

        public string posicao { get; set; }

        public Int32 numero_camisa { get; set; }
    }
}

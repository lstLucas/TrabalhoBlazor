using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroFestasAPI.Models
{
    public class Festa : BaseModel
    {
        public string Nome { get; set; } = "";

        public string Tema { get; set; } = "";

        public DateTime Data { get; set; }
    }
}
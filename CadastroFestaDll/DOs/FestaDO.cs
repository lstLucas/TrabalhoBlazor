using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroFestaDll.DOs
{
    public class FestaDO : BaseDO
    {
        [Required]
        [StringLength(100, ErrorMessage="O nome da festa deve ser inferior a 100 caracteres.")]
        public string Nome { get; set; } = "";

        [StringLength(80, ErrorMessage="O tema deve ser inferior a 80 caracteres")]
        public string Tema { get; set; } = "";

        public DateTime Data { get; set; }
    }
}

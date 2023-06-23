using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroFestaDll.DOs
{
    public class FestaItemDO : BaseDO
    {
        [ForeignKey("Festa")]
        public string IdFesta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter menos que 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage="A quantidade deve ser positiva e menor que 100")]
        public int Quantidade { get; set; }
    }
}
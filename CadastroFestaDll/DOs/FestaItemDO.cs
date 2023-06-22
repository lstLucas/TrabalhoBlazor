using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadastroFestaDll.DOs
{
    public class FestaItemDO : BaseDO
    {
        public string? IdFesta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter menos que 100 caracteres.")]
        public string? Nome { get; set; }

        public DateTime Data { get; set; }
    }
}

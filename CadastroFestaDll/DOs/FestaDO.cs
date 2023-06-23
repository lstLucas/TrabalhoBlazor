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

        [Required(ErrorMessage ="A Data da festa é necessária!")]
        [DataPosteriorAtual(ErrorMessage ="A data da festa deve ser posterior à data atual")]
        
        public DateTime Data { get; set; }
    }

    public class DataPosteriorAtualAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime data = (DateTime)value;
            if (data < DateTime.Now.Date)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}

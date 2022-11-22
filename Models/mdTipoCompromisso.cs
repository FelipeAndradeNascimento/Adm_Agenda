using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Adm_Agenda.Models
{
    [Table("tb_TipoCompromisso")]
    public class mdTipoCompromisso
    {
        [Key]
        [Required]
        public int IdTipoCompromisso { get; set; }

        [Required(ErrorMessage ="Informe o Tipo de Compromisso:")]
        [Display(Name ="Descrição do Tipo de Compromisso")]
        public string DescricaoTipo { get; set; }
    }
}

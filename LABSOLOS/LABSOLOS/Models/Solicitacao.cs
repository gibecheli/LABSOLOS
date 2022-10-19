using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LABSOLOS.Models
{
    [Table("Solicitacoes")]
    public class Solicitacao
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id: ")]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "campo cliente é obrigatório...")]
        [Display(Name = "Cliente")]

        public Cliente cliente { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "campo análise é obrigatório...")]
        [Display(Name = "Analise")]
        public Analise analise { get; set; }

        [Required(ErrorMessage = "campo quantidade é obrigatório...")]
        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "campo data é obrigatório...")]
        [Display(Name = "Data de Entrada")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime dataEntrada { get; set; }

        [Required(ErrorMessage = "campo data de saída é obrigatório...")]
        [Display(Name = "Data de Saída")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime dataSaida { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

    }
}


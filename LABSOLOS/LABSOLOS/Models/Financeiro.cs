using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LABSOLOS.Models
{
    [Table("Financas")]
    public class Financeiro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Conta é obrigatório...")]
        [Display(Name = "Solicitacoes:")]
        public Solicitacao solicitacao { get; set; }

        [Display(Name = "Valor Total:")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        public float valorTotal { get; set; }

        [Required(ErrorMessage = "campo forma de pagamento é obrigatório...")]
        [Display(Name = "Forma de Pagamento:")]
        public string formaPag { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "campo finalizado é obrigatório...")]
        [Display(Name = "Finalizado:")]
        public string finalizado { get; set; }


    }
}


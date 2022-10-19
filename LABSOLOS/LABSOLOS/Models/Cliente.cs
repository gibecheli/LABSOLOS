using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LABSOLOS.Models
{
    public enum Estado { AC, AL, AP, AM, BA, CE, DF, ES, GO, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SC, SP, SE, TO }

    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID:")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório...")]
        [Display(Name = "Nome:")]
        public string nome { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [Display(Name = "CPF:")]
        public string cpf { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Campo cidade é obrigatório...")]
        [Display(Name = "Cidade:")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatório...")]
        [Display(Name = "Estado:")]
        public Estado estado { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Campo propriedade é obrigatório...")]
        [Display(Name = "Nome da Propriedade:")]
        public string Propriedade { get; set; }

    }
}


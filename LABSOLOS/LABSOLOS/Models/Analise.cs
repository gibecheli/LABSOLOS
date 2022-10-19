using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LABSOLOS.Models
{
    [Table("Analises")]
    public class Analise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Amostra")]
        public string amostra { get; set; }

        [Display(Name = "Tipo:")]
        public string tipo { get; set; }

        [Display(Name = "Valor:")]
        [DisplayFormat(DataFormatString = "{0:C3}")]
        public float valor { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

    }
}